Public Class FormDepartemen
    Private koneksi As New KoneksiDB
    Private Sub reset()
        btnHapus.Visible = False
        btnSimpan.Text = "Simpan"
        TabControl1.SelectedIndex = 0
        txtId.Text = koneksi.generateId("DM", "departemen", "id_departemen", 3)
        txtNama.Text = Nothing
        koneksi.isiDataGrid(DataGridView1, "departemen")
        DataGridView1.Columns(0).HeaderText = "ID"
        DataGridView1.Columns(1).HeaderText = "Departemen"
    End Sub

    Private Sub FormDepartemen_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            koneksi.buka()
            reset()
        Catch ex As Exception
            MessageBox.Show(Me, "Terjadi kesalahan! Sumber: " & ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnBatal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBatal.Click
        reset()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub btnHapus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHapus.Click
        Try
            If MessageBox.Show(Me, "Yakin dihapus?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Dim affectedRows As Integer = koneksi.nonQuery("delete from departemen where id_departemen = '" & txtId.Text & "'")
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

    Private Sub btnSimpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSimpan.Click
        Try
            If btnSimpan.Text = "Simpan" Then
                Dim affectedRows As Integer = koneksi.nonQuery("insert into departemen values('" & txtId.Text & "', '" & txtNama.Text & "')")
                If affectedRows > 0 Then
                    MessageBox.Show(Me, "Operasi berhasil dilakukan.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    reset()
                    TabControl1.SelectedIndex = 0
                End If
            ElseIf btnSimpan.Text = "Ubah" Then
                Dim affectedRows As Integer = koneksi.nonQuery("update departemen set nama_departemen = '" & txtNama.Text & "' where id_departemen = '" & txtId.Text & "'")
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

    Private Sub DataGridView1_CellContentDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentDoubleClick
        Dim row As DataGridViewRow = DataGridView1.CurrentRow

        txtId.Text = row.Cells(0).Value
        txtNama.Text = row.Cells(1).Value

        btnHapus.Visible = True
        btnSimpan.Text = "Ubah"

        TabControl1.SelectedIndex = 1
    End Sub

    Private Sub DataGridView1_RowHeaderMouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView1.RowHeaderMouseDoubleClick
        Dim row As DataGridViewRow = DataGridView1.CurrentRow

        txtId.Text = row.Cells(0).Value
        txtNama.Text = row.Cells(1).Value

        btnHapus.Visible = True
        btnSimpan.Text = "Ubah"

        TabControl1.SelectedIndex = 1
    End Sub
End Class