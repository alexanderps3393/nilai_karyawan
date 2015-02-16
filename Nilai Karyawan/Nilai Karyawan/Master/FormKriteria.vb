Public Class FormKriteria

    Private koneksi As KoneksiDB = New KoneksiDB

    Private Sub FormKriteria_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            koneksi.buka()
            reset()
        Catch ex As Exception
            MessageBox.Show(Me, "Terjadi kesalahan! SUmber: " & ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub reset()
        txtIdKriteria.Text = koneksi.generateId("KR", "kriteria", "id_kriteria", 3)
        txtNamaKriteria.Text = Nothing
        txtKeterangan.Text = Nothing
        Button2.Visible = False
        Button1.Text = "Simpan"
        koneksi.isiDataGrid(DataGridView1, "kriteria")
        DataGridView1.Columns(0).HeaderText = "Id"
        DataGridView1.Columns(0).Width = 30
        DataGridView1.Columns(1).HeaderText = "Kriteria"
        DataGridView1.Columns(1).Width = 75
        DataGridView1.Columns(2).HeaderText = "Keterangan"
        TabControl1.SelectedIndex = 0
    End Sub

    Private Sub btnKembali_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnKembali.Click
        Me.Close()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        reset()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            If Button1.Text = "Simpan" Then
                Dim query As String = "insert into kriteria values('" & txtIdKriteria.Text & "', '" & txtNamaKriteria.Text & "', '" & txtKeterangan.Text & "')"
                Dim affectedRows = koneksi.nonQuery(query)
                If affectedRows > 0 Then
                    MessageBox.Show(Me, "Operasi berhasil dilakukan.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    reset()
                Else
                    MessageBox.Show(Me, "Operasi gagal dilakukan.", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            ElseIf Button1.Text = "Ubah" Then
                Dim query As String = "update kriteria set nama_kriteria = '" & txtNamaKriteria.Text & "', ket_kriteria = '" & txtKeterangan.Text & "' where id_kriteria = '" & txtIdKriteria.Text & "'"
                Dim affectedRows = koneksi.nonQuery(query)
                If affectedRows > 0 Then
                    MessageBox.Show(Me, "Operasi berhasil dilakukan.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    reset()
                Else
                    MessageBox.Show(Me, "Operasi gagal dilakukan.", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(Me, "Terjadi kesalahan! Sumber: " & ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            If MessageBox.Show(Me, "Yakin dihapus?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Dim query As String = "delete from kriteria where id_kriteria = '" & txtIdKriteria.Text & "'"
                Dim affectedRows = koneksi.nonQuery(query)
                If affectedRows > 0 Then
                    MessageBox.Show(Me, "Operasi berhasil dilakukan.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    reset()
                Else
                    MessageBox.Show(Me, "Operasi gagal dilakukan.", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(Me, "Terjadi kesalahan! Sumber: " & ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub DataGridView1_RowHeaderMouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView1.RowHeaderMouseDoubleClick
        Dim row As DataGridViewRow = DataGridView1.CurrentRow

        txtIdKriteria.Text = row.Cells(0).Value
        txtNamaKriteria.Text = row.Cells(1).Value
        txtKeterangan.Text = row.Cells(2).Value

        Button2.Visible = True
        Button1.Text = "Ubah"

        TabControl1.SelectedIndex = 1
    End Sub

    Private Sub DataGridView1_CellContentDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentDoubleClick
        Dim row As DataGridViewRow = DataGridView1.CurrentRow

        txtIdKriteria.Text = row.Cells(0).Value
        txtNamaKriteria.Text = row.Cells(1).Value
        txtKeterangan.Text = row.Cells(2).Value

        Button2.Visible = True
        Button1.Text = "Ubah"

        TabControl1.SelectedIndex = 1
    End Sub
End Class