Public Class FormFilter1

    Private koneksi As New KoneksiDB
    Private manajer As String

    Private Sub FormFilter1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            koneksi.buka()
            koneksi.isiComboBox(ComboBox1, "periode_penilaian", "tahun_periode", "tahun_periode")
        Catch ex As Exception
            MessageBox.Show(Me, "Terjadi kesalahan!" & vbNewLine & "Sumber: " & ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If ComboBox1.Text = Nothing Or ComboBox1.Text = "" Then
            MessageBox.Show(Me, "Mohon pilih tahun penilaian.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            Dim laporan As New FormLaporan1
            laporan.SetTahun(ComboBox1.Text)
            laporan.SetManajer(Me.manajer)
            laporan.ShowDialog(Me)
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Public Sub SetManajer(ByVal manajer As String)
        Me.manajer = manajer
    End Sub
End Class