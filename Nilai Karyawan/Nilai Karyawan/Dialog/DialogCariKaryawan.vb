Imports System.Windows.Forms

Public Class DialogCariKaryawan
    Private koneksi As KoneksiDB = New KoneksiDB
    Public id, nama, jk, alamat, departemen, golongan As String
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Dim row As DataGridViewRow = DataGridView1.CurrentRow
        id = row.Cells(0).Value
        departemen = row.Cells(2).Value
        golongan = row.Cells(4).Value
        nama = row.Cells(5).Value
        jk = row.Cells(6).Value
        alamat = row.Cells(7).Value
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub DialogCariKaryawan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            koneksi.buka()
            Dim query As String = "select id_karyawan, a.id_departemen, nama_departemen, a.id_golongan, nama_golongan, nama_karyawan, jk_karyawan, alamat_karyawan from karyawan a, departemen b, golongan c where a.id_departemen = b.id_departemen and a.id_golongan = c.id_golongan"
            koneksi.queryDataGrid(DataGridView1, query)
            DataGridView1.Columns(0).HeaderText = "ID"
            DataGridView1.Columns(1).Visible = False
            DataGridView1.Columns(2).HeaderText = "Departemen"
            DataGridView1.Columns(3).Visible = False
            DataGridView1.Columns(4).HeaderText = "Golongan"
            DataGridView1.Columns(5).HeaderText = "Nama"
            DataGridView1.Columns(6).HeaderText = "Jenis Kel."
            DataGridView1.Columns(7).HeaderText = "Alamat"
            ComboBox1.SelectedIndex = 0
        Catch ex As Exception
            MessageBox.Show(Me, "Terjadi kesalahan!" & vbNewLine & "Sumber: " & ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        Try
            Dim query As String = ""
            If ComboBox1.Text = "ID" Then
                query = "select id_karyawan, a.id_departemen, nama_departemen, a.id_golongan, nama_golongan, nama_karyawan, jk_karyawan, alamat_karyawan from karyawan a, departemen b, golongan c where a.id_departemen = b.id_departemen and a.id_golongan = c.id_golongan and id_karyawan like '%" & TextBox1.Text & "%'"
            ElseIf ComboBox1.Text = "Nama" Then
                query = "select id_karyawan, a.id_departemen, nama_departemen, a.id_golongan, nama_golongan, nama_karyawan, jk_karyawan, alamat_karyawan from karyawan a, departemen b, golongan c where a.id_departemen = b.id_departemen and a.id_golongan = c.id_golongan and nama_karyawan like '%" & TextBox1.Text & "%'"
            Else
                query = "select id_karyawan, a.id_departemen, nama_departemen, a.id_golongan, nama_golongan, nama_karyawan, jk_karyawan, alamat_karyawan from karyawan a, departemen b, golongan c where a.id_departemen = b.id_departemen and a.id_golongan = c.id_golongan and alamat_karyawan like '%" & TextBox1.Text & "%'"
            End If
            koneksi.queryDataGrid(DataGridView1, query)
            DataGridView1.Columns(0).HeaderText = "ID"
            DataGridView1.Columns(1).Visible = False
            DataGridView1.Columns(2).HeaderText = "Departemen"
            DataGridView1.Columns(3).Visible = False
            DataGridView1.Columns(4).HeaderText = "Golongan"
            DataGridView1.Columns(5).HeaderText = "Nama"
            DataGridView1.Columns(6).HeaderText = "Jenis Kel."
            DataGridView1.Columns(7).HeaderText = "Alamat"
        Catch ex As Exception
            MessageBox.Show(Me, "Terjadi kesalahan!" & vbNewLine & "Sumber: " & ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
