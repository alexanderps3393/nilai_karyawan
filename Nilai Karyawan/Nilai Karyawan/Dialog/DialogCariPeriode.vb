Imports System.Windows.Forms

Public Class DialogCariPeriode
    Public id As String
    Private koneksi As New KoneksiDB
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Dim row As DataGridViewRow = DataGridView1.CurrentRow
        id = row.Cells(0).Value
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        Try
            Dim query As String = ""
            If ComboBox1.Text = "ID" Then
                query = "select * from periode_penilaian where id_periode like '%" & TextBox1.Text & "%'"
            ElseIf ComboBox1.Text = "Nama" Then
                query = "select * from periode_penilaian where nama_periode like '%" & TextBox1.Text & "%'"
            Else
                query = "select * from periode_penilaian where tahun_periode like '%" & TextBox1.Text & "%'"
            End If
            koneksi.queryDataGrid(DataGridView1, query)
            DataGridView1.Columns(0).HeaderText = "ID"
            DataGridView1.Columns(1).HeaderText = "Nama"
            DataGridView1.Columns(2).HeaderText = "Tahun"
            DataGridView1.Columns(3).HeaderText = "Keterangan"
        Catch ex As Exception
            MessageBox.Show(Me, "Terjadi kesalahan!" & vbNewLine & "Sumber: " & ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub DialogCariPeriode_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            koneksi.buka()
            Dim query As String = "select * from periode_penilaian"
            koneksi.queryDataGrid(DataGridView1, query)
            DataGridView1.Columns(0).HeaderText = "ID"
            DataGridView1.Columns(1).HeaderText = "Nama"
            DataGridView1.Columns(2).HeaderText = "Tahun"
            DataGridView1.Columns(3).HeaderText = "Keterangan"
            ComboBox1.SelectedIndex = 0
        Catch ex As Exception
            MessageBox.Show(Me, "Terjadi kesalahan!" & vbNewLine & "Sumber: " & ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
