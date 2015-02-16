Public Class FormPrePenilaian
    Private koneksi As New KoneksiDB
    Private nip As String
    Public Sub SetNIP(ByVal nip As String)
        Me.nip = nip
    End Sub
    Public Sub reset()
        txtId.Text = koneksi.generateId("PEN", "penilaian", "id_penilaian", 7)
        txtIdKaryawan.Text = Nothing
        txtIdPeriode.Text = Nothing
        txtNilai.Text = Nothing
        dtpTanggal.Value = Now()
        btnSimpan.Text = "Simpan"
        btnDetil.Enabled = False
        btnProses.Enabled = False
        isidata()
        TabControl1.SelectedIndex = 0
    End Sub

    Public Sub isidata()
        Dim query As String = "select id_penilaian, b.nama_karyawan, b.id_karyawan, c.nama_periode, c.tahun_periode, c.id_periode, d.nama_manajer, d.nip_manajer, tgl_penilaian, hasil_penilaian from penilaian a, karyawan b, periode_penilaian c, manajer d where a.id_karyawan = b.id_karyawan and a.id_periode = c.id_periode and a.nip_manajer = d.nip_manajer"
        koneksi.queryDataGrid(DataGridView1, query)
        DataGridView1.Columns(0).HeaderText = "ID"
        DataGridView1.Columns(1).HeaderText = "Karyawan"
        DataGridView1.Columns(2).HeaderText = "ID Karyawan"
        DataGridView1.Columns(3).HeaderText = "Periode"
        DataGridView1.Columns(4).HeaderText = "Tahun"
        DataGridView1.Columns(5).Visible = False
        DataGridView1.Columns(6).HeaderText = "Manajer"
        DataGridView1.Columns(7).HeaderText = "NIP Manajer"
        DataGridView1.Columns(8).HeaderText = "Tanggal Penilaian"
        DataGridView1.Columns(9).HeaderText = "Total Nilai"
    End Sub

    Private Sub FormPrePenilaian_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            koneksi.buka()
            reset()
        Catch ex As Exception
            MessageBox.Show(Me, "Terjadi kesalahan!" & vbNewLine & "Sumber: " & ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnKembali_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnKembali.Click
        Me.Close()
    End Sub

    Private Sub btnBatal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBatal.Click
        reset()
    End Sub

    Private Sub btnSimpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSimpan.Click
        Try
            Dim tanggal As String = dtpTanggal.Value.Year & "-" & dtpTanggal.Value.Month & "-" & dtpTanggal.Value.Day
            If btnSimpan.Text = "Simpan" Then
                Dim affectedRows As Integer = koneksi.nonQuery("insert into penilaian values('" & txtId.Text & "', '" & txtIdKaryawan.Text & "', '" & txtIdPeriode.Text & "', '" & nip & "', '" & tanggal & "', '" & txtNilai.Text & "')")
                If affectedRows > 0 Then
                    MessageBox.Show(Me, "Operasi berhasil dilakukan" & vbNewLine & "Silahkan lanjutkan dengan Proses Penilaian", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    isidata()
                    btnProses.Enabled = True
                    btnDetil.Enabled = True
                    btnSimpan.Text = "Ubah"
                Else
                    MessageBox.Show(Me, "Operasi gagal dilakukan", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            ElseIf btnSimpan.Text = "Ubah" Then
                Dim affectedRows As Integer = koneksi.nonQuery("update penilaian set id_karyawan = '" & txtIdKaryawan.Text & "', id_periode = '" & txtIdPeriode.Text & "', nip_manajer = '" & nip & "', tgl_penilaian = '" & tanggal & "' where id_penilaian = '" & txtId.Text & "'")
                If affectedRows > 0 Then
                    MessageBox.Show(Me, "Operasi berhasil dilakukan" & vbNewLine & "Silahkan lanjutkan dengan Proses Penilaian", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    isidata()
                    btnProses.Enabled = True
                    btnDetil.Enabled = True
                    btnSimpan.Text = "Ubah"
                Else
                    MessageBox.Show(Me, "Operasi gagal dilakukan", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(Me, "Terjadi kesalahan!" & vbNewLine & "Sumber: " & ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnCariKaryawan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCariKaryawan.Click
        Dim cariKaryawan As New DialogCariKaryawan
        Dim hasil As DialogResult = cariKaryawan.ShowDialog(Me)
        If hasil = Windows.Forms.DialogResult.OK Then
            txtIdKaryawan.Text = cariKaryawan.id
        End If
    End Sub

    Private Sub btnCariPeriode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCariPeriode.Click
        Dim cariPeriode As New DialogCariPeriode
        Dim hasil As DialogResult = cariPeriode.ShowDialog(Me)
        If hasil = Windows.Forms.DialogResult.OK Then
            txtIdPeriode.Text = cariPeriode.id
        End If
    End Sub

    Private Sub DataGridView1_CellContentDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentDoubleClick
        Dim row As DataGridViewRow = DataGridView1.CurrentRow
        txtId.Text = row.Cells(0).Value
        txtIdKaryawan.Text = row.Cells(2).Value
        txtIdPeriode.Text = row.Cells(5).Value
        dtpTanggal.Value = row.Cells(8).Value
        txtNilai.Text = row.Cells(9).Value
        btnSimpan.Text = "Ubah"
        btnDetil.Enabled = True
        btnProses.Enabled = True
        TabControl1.SelectedIndex = 1
    End Sub

    Private Sub DataGridView1_RowHeaderMouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView1.RowHeaderMouseDoubleClick
        Dim row As DataGridViewRow = DataGridView1.CurrentRow
        txtId.Text = row.Cells(0).Value
        txtIdKaryawan.Text = row.Cells(2).Value
        txtIdPeriode.Text = row.Cells(5).Value
        dtpTanggal.Value = row.Cells(8).Value
        txtNilai.Text = row.Cells(9).Value
        btnSimpan.Text = "Ubah"
        btnDetil.Enabled = True
        btnProses.Enabled = True
        TabControl1.SelectedIndex = 1
    End Sub

    Private Sub btnDetil_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDetil.Click
        Dim detil As New DialogDetil
        detil.SetIdPenilaian(txtId.Text)
        detil.ShowDialog(Me)
    End Sub

    Private Sub btnProses_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProses.Click
        Try
            Dim proses As New DialogProsesPerhitungan
            proses.id_penilaian = txtId.Text
            proses.id_karyawan = txtIdKaryawan.Text
            If txtNilai.Text = "0" Or txtNilai.Text = Nothing Or txtNilai.Text = "0.00" Or txtNilai.Text = "" Then
                proses.status = "new"
            Else
                proses.status = "update"
            End If
            Dim hasil As DialogResult = proses.ShowDialog(Me)
            If hasil = Windows.Forms.DialogResult.OK Then
                txtNilai.Text = Convert.ToString(proses.HitungTotalNilai)
                koneksi.nonQuery("update penilaian set hasil_penilaian = '" & txtNilai.Text & "' where id_penilaian = '" & txtId.Text & "'")
            End If
        Catch ex As Exception
            MessageBox.Show(Me, "Terjadi kesalahan!" & vbNewLine & "Sumber: " & ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class