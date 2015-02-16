Imports MySql.Data.MySqlClient

Public Class Form1

    Dim koneksi As KoneksiDB = New KoneksiDB("nilai_karyawan")

    Private Sub button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles button2.Click
        Application.Exit()
    End Sub

    Private Sub button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles button1.Click
        Try
            If textBox1.Text <> "" And textBox2.Text <> "" Then
                If authLogin(textBox1.Text, textBox2.Text) Then
                    ' Login diterima
                    Dim utama As FormUtama = New FormUtama
                    utama.setNip(textBox1.Text)
                    utama.setUsername(getNamaManajer(textBox1.Text))
                    utama.setDatabase(koneksi.getDatabaseName())
                    utama.Show()
                    Me.Hide()
                Else
                    MessageBox.Show("Login ditolak, silahkan coba lagi!", "Ditolak", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    reset()
                End If
            Else
                MessageBox.Show("Mohon isi kolom form login terlebih dahulu!", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            MessageBox.Show("Terjadi kesalahan! Sumber: " & ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub reset()
        textBox1.Text = Nothing
        textBox2.Text = Nothing
    End Sub

    Private Function authLogin(ByVal nip As String, ByVal pass As String) As Boolean
        Dim query As String = "select * from manajer where NIP_MANAJER = '" & nip & "' and PASS_MANAJER = '" & pass & "'"
        Dim command As MySqlCommand = New MySqlCommand(query, koneksi.getKoneksi())
        Dim adapter As MySqlDataAdapter = New MySqlDataAdapter(command)
        Dim datatable As DataTable = New DataTable
        adapter.Fill(datatable)
        If datatable.Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Function getNamaManajer(ByVal nip As String) As String
        Dim nama As String = ""
        Dim query As String = "select NAMA_MANAJER from manajer where NIP_MANAJER = '" & nip & "'"
        Dim command As MySqlCommand = New MySqlCommand(query, koneksi.getKoneksi())
        Dim reader As MySqlDataReader = command.ExecuteReader
        While reader.Read
            nama = reader(0)
        End While
        reader.Close()
        Return nama
    End Function

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            koneksi.buka()
        Catch ex As Exception
            MessageBox.Show("Terjadi kesalahan! Sumber: " & ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
