Imports MySql.Data.MySqlClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class FormLaporan1
    Private koneksi As New KoneksiDB
    Private adapter As New MySqlDataAdapter
    Private command As New MySqlCommand
    Private tahun, manajer As String

    Private Sub FormLaporan1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            koneksi.buka()
            IsiReport()
        Catch ex As Exception
            MessageBox.Show(Me, "Terjadi kesalahan!" & vbNewLine & "Sumber: " & ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub SetTahun(ByVal tahun As String)
        Me.tahun = tahun
    End Sub

    Public Sub SetManajer(ByVal manajer As String)
        Me.manajer = manajer
    End Sub

    Private Sub IsiReport()
        Dim ds As New DataSet
        Dim cmd As New MySqlCommand
        Dim adapter As New MySqlDataAdapter

        cmd.CommandText = "SELECT periode_penilaian.TAHUN_PERIODE, periode_penilaian.NAMA_PERIODE, karyawan.NAMA_KARYAWAN, golongan.NAMA_GOLONGAN, departemen.NAMA_DEPARTEMEN, manajer.NAMA_MANAJER, penilaian.TGL_PENILAIAN, penilaian.HASIL_PENILAIAN FROM departemen INNER JOIN karyawan ON departemen.ID_DEPARTEMEN = karyawan.ID_DEPARTEMEN INNER JOIN golongan ON karyawan.ID_GOLONGAN = golongan.ID_GOLONGAN INNER JOIN penilaian ON karyawan.ID_KARYAWAN = penilaian.ID_KARYAWAN INNER JOIN manajer ON penilaian.NIP_MANAJER = manajer.NIP_MANAJER INNER JOIN periode_penilaian ON penilaian.ID_PERIODE = periode_penilaian.ID_PERIODE"
        cmd.CommandType = CommandType.Text
        cmd.Connection = koneksi.getKoneksi
        adapter.SelectCommand = cmd
        adapter.Fill(ds)
        ds.WriteXml("Penilaian Semua Karyawan.xml", XmlWriteMode.WriteSchema)

        ReportPenilaian11.SetParameterValue("Tahun", Val(Me.tahun))
        ReportPenilaian11.SetParameterValue("Manajer", Me.manajer)
        CrystalReportViewer1.ReportSource = ReportPenilaian11
        CrystalReportViewer1.Refresh()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub
End Class