Imports MySql.Data.MySqlClient

Public Class FormKaryawan

    Private koneksi As KoneksiDB = New KoneksiDB()
    Private command As MySqlCommand
    Private adapter As MySqlDataAdapter
    Private reader As MySqlDataReader
    Private dataset As DataSet
    Private datatable As DataTable

    Private Sub btnKembali_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnKembali.Click
        Me.Close()
    End Sub

    Private Function pilihJenKel() As String
        If rbLakiLaki.Checked Then
            Return "L"
        Else
            Return "P"
        End If
    End Function

    Private Sub reset()
        txtIdKaryawan.Text = koneksi.generateId("KAR", "karyawan", "id_karyawan", 5)
        txtNamaKaryawan.Text = Nothing
        rbLakiLaki.Checked = False
        rbPerempuan.Checked = False
        txtAlamat.Text = Nothing
        btnHapus.Visible = False
        cbDepartemen.Text = Nothing
        cbGolongan.Text = Nothing
        btnSimpan.Text = "Simpan"
        Dim query As String = "select id_karyawan, a.id_departemen, nama_departemen, a.id_golongan, nama_golongan, nama_karyawan, jk_karyawan, alamat_karyawan from karyawan a, departemen b, golongan c where a.id_departemen = b.id_departemen and a.id_golongan = c.id_golongan"
        koneksi.queryDataGrid(dgvKaryawan, query)
        dgvKaryawan.Columns(0).HeaderText = "ID"
        dgvKaryawan.Columns(1).Visible = False
        dgvKaryawan.Columns(2).HeaderText = "Departemen"
        dgvKaryawan.Columns(3).Visible = False
        dgvKaryawan.Columns(4).HeaderText = "Golongan"
        dgvKaryawan.Columns(5).HeaderText = "Nama"
        dgvKaryawan.Columns(6).HeaderText = "Jenis Kel."
        dgvKaryawan.Columns(7).HeaderText = "Alamat"
    End Sub

    Private Sub btnBatal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBatal.Click
        reset()
    End Sub

    Private Sub FormKaryawan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            koneksi.buka()
            koneksi.isiComboBox(cbDepartemen, "departemen", "id_departemen", "nama_departemen")
            koneksi.isiComboBox(cbGolongan, "golongan", "id_golongan", "nama_golongan")
            reset()
        Catch ex As Exception
            MessageBox.Show(Me, "Terjadi kesalahan! Sumber: " & ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnSimpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSimpan.Click
        Try
            If btnSimpan.Text = "Simpan" Then
                Dim affectedRows As Integer = koneksi.nonQuery("insert into karyawan values('" & _
                         txtIdKaryawan.Text & "', '" & _
                         cbDepartemen.SelectedValue & "', '" & _
                         cbGolongan.SelectedValue & "', '" & _
                         txtNamaKaryawan.Text & "', '" & _
                         pilihJenKel() & "', '" & _
                         txtAlamat.Text & "')")
                If affectedRows > 0 Then
                    MessageBox.Show(Me, "Operasi berhasil dilakukan.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    reset()
                    TabControl1.SelectedIndex = 0
                End If
            ElseIf btnSimpan.Text = "Ubah" Then
                Dim affectedRows As Integer = koneksi.nonQuery("update karyawan set id_departemen = '" & cbDepartemen.SelectedValue & "', id_golongan = '" & cbGolongan.SelectedValue & "', nama_karyawan = '" & txtNamaKaryawan.Text & "', jk_karyawan = '" & pilihJenKel() & "', alamat_karyawan = '" & txtAlamat.Text & "' where id_karyawan = '" & txtIdKaryawan.Text & "'")
                If affectedRows > 0 Then
                    MessageBox.Show(Me, "Operasi berhasil dilakukan.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    reset()
                    TabControl1.SelectedIndex = 0
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(Me, "Terjadi kesalahan! Sumber: " & ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgvKaryawan_CellContentDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvKaryawan.CellContentDoubleClick
        Dim row As DataGridViewRow = dgvKaryawan.CurrentRow

        txtIdKaryawan.Text = row.Cells(0).Value
        cbDepartemen.SelectedValue = row.Cells(1).Value
        cbGolongan.SelectedValue = row.Cells(3).Value
        txtNamaKaryawan.Text = row.Cells(5).Value
        If row.Cells(6).Value = "L" Then
            rbLakiLaki.Checked = True
        Else
            rbPerempuan.Checked = True
        End If
        txtAlamat.Text = row.Cells(7).Value

        btnHapus.Visible = True
        btnSimpan.Text = "Ubah"

        TabControl1.SelectedIndex = 1
    End Sub

    Private Sub btnHapus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHapus.Click
        Try
            If MessageBox.Show(Me, "Yakin dihapus?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Dim affectedRows As Integer = koneksi.nonQuery("delete from karyawan where id_karyawan = '" & txtIdKaryawan.Text & "'")
                If affectedRows > 0 Then
                    MessageBox.Show(Me, "Operasi berhasil dilakukan.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    reset()
                    TabControl1.SelectedIndex = 0
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(Me, "Terjadi kesalahan! Sumber: " & ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgvKaryawan_RowHeaderMouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvKaryawan.RowHeaderMouseDoubleClick
        Dim row As DataGridViewRow = dgvKaryawan.CurrentRow

        txtIdKaryawan.Text = row.Cells(0).Value
        cbDepartemen.SelectedValue = row.Cells(1).Value
        cbGolongan.SelectedValue = row.Cells(3).Value
        txtNamaKaryawan.Text = row.Cells(5).Value
        If row.Cells(6).Value = "L" Then
            rbLakiLaki.Checked = True
        Else
            rbPerempuan.Checked = True
        End If
        txtAlamat.Text = row.Cells(7).Value

        btnHapus.Visible = True
        btnSimpan.Text = "Ubah"

        TabControl1.SelectedIndex = 1
    End Sub
End Class