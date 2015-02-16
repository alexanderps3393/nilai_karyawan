Imports System.Windows.Forms

Public Class DialogProsesPerhitungan
    Private koneksi As New KoneksiDB
    Public id_penilaian, status, id_karyawan As String
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        If CekKosong() Then
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()
        Else
            MessageBox.Show(Me, "Masih ada kriteria yang belum dinilai." & vbNewLine & "Mohon isi semua nilai kriteria", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Function CekKosong() As Boolean
        Dim nilai As String = ""
        For index As Integer = 0 To dgvKriteria.RowCount - 1
            Dim row As DataGridViewRow = dgvKriteria.Rows(index)
            If row.Cells(3).Value = Nothing Then
                nilai += "0"
            Else
                nilai += "1"
            End If
        Next
        If nilai.Contains("0") Then
            Return False
        Else
            Return True
        End If
    End Function

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub isiDataGridKriteria()
        Try
            koneksi.buka()
            koneksi.isiDataGrid(dgvKriteria, "kriteria")
            dgvKriteria.Columns(0).Visible = False
            dgvKriteria.Columns(2).Visible = False
            dgvKriteria.Columns(1).HeaderText = "Kriteria"
            dgvKriteria.Columns.Add("nilai", "Nilai")
            dgvKriteria.Columns(3).Width = 50
        Catch ex As Exception
            MessageBox.Show(Me, "Terjadi kesalahan!" & vbNewLine & "Sumber: " & ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub DialogProsesPerhitungan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        isiDataGridKriteria()
        isiCbNilai()
    End Sub

    Private Sub isiCbNilai()
        For i As Integer = 100 To 30 Step -5
            cbNilai.Items.Add(i)
        Next
    End Sub

    Private Sub isiDataGridNilai(ByVal id As String)
        Try
            koneksi.queryDataGrid(dgvNilai, "select ket_range, nilai_atas, nilai_bawah from range_nilai where id_kriteria = '" & id & "'")
            dgvNilai.Columns(0).HeaderText = "Keterangan"
            dgvNilai.Columns(1).HeaderText = "Mulai"
            dgvNilai.Columns(1).Width = 30
            dgvNilai.Columns(2).HeaderText = "Sampai"
            dgvNilai.Columns(2).Width = 30
            If txtKriteria.Text.Contains("Absensi") Or txtKriteria.Text.Contains("Presensi") Then
                koneksi.queryDataGrid(dgvNilai, "select nama_rekap as Periode, tahun_rekap as Tahun, tgl_rekap as Tanggal, terlambat as Terlambat, absen as Absen, sakit as Ijin from rekap_kehadiran where id_karyawan = '" & Me.id_karyawan & "'")
            End If
        Catch ex As Exception
            MessageBox.Show(Me, "Terjadi kesalahan!" & vbNewLine & "Sumber: " & ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgvKriteria_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvKriteria.CellContentClick
        Dim row As DataGridViewRow = dgvKriteria.CurrentRow
        txtIdKriteria.Text = row.Cells(0).Value
        txtDeskripsi.Text = row.Cells(2).Value
        txtKriteria.Text = row.Cells(1).Value
        cbNilai.Text = row.Cells(3).Value
        isiDataGridNilai(txtIdKriteria.Text)
    End Sub

    Private Sub dgvKriteria_RowHeaderMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvKriteria.RowHeaderMouseClick
        Dim row As DataGridViewRow = dgvKriteria.CurrentRow
        txtIdKriteria.Text = row.Cells(0).Value
        txtDeskripsi.Text = row.Cells(2).Value
        txtKriteria.Text = row.Cells(1).Value
        cbNilai.Text = row.Cells(3).Value
        isiDataGridNilai(txtIdKriteria.Text)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            For index As Integer = 0 To dgvKriteria.RowCount - 1
                Dim row As DataGridViewRow = dgvKriteria.Rows(index)
                If row.Cells(0).Value = txtIdKriteria.Text Then
                    row.Cells(3).Value = cbNilai.Text
                End If
            Next
        Catch ex As Exception
            MessageBox.Show(Me, "Terjadi kesalahan!" & vbNewLine & "Sumber: " & ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Function HitungTotalNilai() As Integer
        Dim totalnilai As Integer = 0
        Dim rata2 As Integer
        For index As Integer = 0 To dgvKriteria.RowCount - 1
            Dim row As DataGridViewRow = dgvKriteria.Rows(index)
            Dim idkriteria As String = row.Cells(0).Value
            If status = "new" Then
                koneksi.nonQuery("insert into detil_penilaian values('" & id_penilaian & "', '" & idkriteria & "', '" & row.Cells(3).Value & "')")
            ElseIf status = "update" Then
                koneksi.nonQuery("update detil_penilaian set nilai = " & row.Cells(3).Value & " where id_penilaian = '" & id_penilaian & "' and id_kriteria = '" & idkriteria & "'")
            End If
            totalnilai += row.Cells(3).Value
        Next
        rata2 = totalnilai / dgvKriteria.RowCount
        Return rata2
    End Function

End Class
