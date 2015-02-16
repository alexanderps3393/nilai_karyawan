Imports System.Windows.Forms
Imports MySql.Data.MySqlClient

Public Class DialogDetil

    Private id_penilaian As String
    Private koneksi As New KoneksiDB

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub DialogDetil_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            koneksi.buka()
            isiTextBox()
            Dim query As String = "select a.id_penilaian, a.id_kriteria, b.nama_kriteria, a.nilai from detil_penilaian a, kriteria b where a.id_kriteria = b.id_kriteria and id_penilaian = '" & id_penilaian & "'"
            koneksi.queryDataGrid(DataGridView1, query)

            DataGridView1.Columns(0).Visible = False
            DataGridView1.Columns(1).Visible = False
            DataGridView1.Columns(2).HeaderText = "Kriteria"
            DataGridView1.Columns(3).HeaderText = "Nilai"
            DataGridView1.Columns(3).Width = 75
            TextBox7.Text = hitungTotal()
            TextBox8.Text = NilaiHuruf(TextBox7.Text)
            TextBox9.Text = NilaiKeterangan(TextBox8.Text)
        Catch ex As Exception
            MessageBox.Show(Me, "Terjadi kesalahan!" & vbNewLine & "Sumber: " & ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub SetIdPenilaian(ByVal id As String)
        Me.id_penilaian = id
    End Sub

    Private Sub isiTextBox()
        Dim query As String = "SELECT a.tgl_penilaian, c.nama_periode, c.tahun_periode, d.nama_manajer, b.nama_karyawan, a.id_karyawan, e.nama_departemen, f.nama_golongan FROM penilaian a, karyawan b, periode_penilaian c, manajer d, departemen e, golongan f where a.id_karyawan = b.id_karyawan and a.id_periode = c.id_periode and a.nip_manajer = d.nip_manajer and b.id_departemen = e.id_departemen and b.id_golongan = f.id_golongan and id_penilaian = '" & id_penilaian & "'"
        Dim command As New MySqlCommand(query, koneksi.getKoneksi)
        Dim reader As MySqlDataReader = command.ExecuteReader
        While reader.Read
            TextBox1.Text = reader(0)
            TextBox2.Text = reader(1) & " " & reader(2)
            TextBox3.Text = reader(3)
            TextBox6.Text = reader(4)
            TextBox5.Text = reader(5)
            TextBox4.Text = reader(6) & " / " & reader(7)
        End While
        reader.Close()
    End Sub

    Private Function hitungTotal() As String
        Dim totalnilai As Integer = 0
        Dim rata2 As Integer
        For index As Integer = 0 To DataGridView1.RowCount - 1
            Dim row As DataGridViewRow = DataGridView1.Rows(index)
            totalnilai += row.Cells(3).Value
        Next
        rata2 = totalnilai / DataGridView1.RowCount
        Return Convert.ToString(rata2)
    End Function

    Private Function NilaiHuruf(ByVal nilai As Integer) As String
        Dim huruf As String = ""
        If nilai > 90 Then
            huruf = "A"
        ElseIf nilai > 78 Then
            huruf = "B"
        ElseIf nilai > 65 Then
            huruf = "C"
        ElseIf nilai > 48 Then
            huruf = "D"
        Else
            huruf = "E"
        End If
        Return huruf
    End Function

    Private Function NilaiKeterangan(ByVal nilai As String) As String
        Dim kategori As String = ""
        If nilai = "A" Then
            kategori = "Sangat Baik"
        ElseIf nilai = "B" Then
            kategori = "Baik"
        ElseIf nilai = "C" Then
            kategori = "Cukup"
        ElseIf nilai = "D" Then
            kategori = "Kurang"
        Else
            kategori = "Sangat Kurang"
        End If
        Return kategori
    End Function

End Class
