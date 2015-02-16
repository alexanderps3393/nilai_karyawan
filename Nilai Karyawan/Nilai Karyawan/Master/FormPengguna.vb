Public Class FormPengguna

    Private nip, nama As String

    Public Sub SetNip(ByVal nip As String)
        Me.nip = nip
    End Sub

    Public Sub SetNama(ByVal nama As String)
        Me.nama = nama
    End Sub

    Private Sub FormPengguna_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TextBox1.Text = nip
        TextBox2.Text = nama
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Dim koneksi As New KoneksiDB
            koneksi.buka()
            Dim affectedRows As Integer = koneksi.nonQuery("update manajer set pass_manajer = '" & TextBox3.Text & "', nama_manajer = '" & TextBox2.Text & "' where nip_manajer = '" & TextBox1.Text & "'")
            If affectedRows > 0 Then
                MessageBox.Show(Me, "Kata kunci berhasil diubah", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TextBox3.Text = Nothing
            Else
                MessageBox.Show(Me, "Kata kunci gagal diubah", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show(Me, "Terjadi kesalahan!" & vbNewLine & "Sumber: " & ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class