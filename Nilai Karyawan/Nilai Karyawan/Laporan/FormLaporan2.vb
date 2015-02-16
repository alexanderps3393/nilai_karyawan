Public Class FormLaporan2

    Private koneksi As New KoneksiDB
    Private tahun, karyawan As String

    Private Sub FormLaporan2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

    Public Sub SetKaryawan(ByVal karyawan As String)
        Me.karyawan = karyawan
    End Sub

    Private Sub IsiReport()
        Dim ds As New DataSet
        Dim adapter As New MySql.Data.MySqlClient.MySqlDataAdapter
        Dim cmd As New MySql.Data.MySqlClient.MySqlCommand
        Dim dt As New DataTable

        cmd.CommandType = CommandType.Text
        cmd.Connection = koneksi.getKoneksi
        cmd.CommandText = "SELECT * FROM departemen"
        adapter.SelectCommand = cmd
        adapter.Fill(ds, "Departemen")

        cmd.CommandText = "SELECT * FROM detil_penilaian"
        adapter.SelectCommand = cmd
        adapter.Fill(ds, "Detil_Penilaian")

        cmd.CommandText = "SELECT * FROM golongan"
        adapter.SelectCommand = cmd
        adapter.Fill(ds, "Golongan")

        cmd.CommandText = "SELECT * FROM karyawan"
        adapter.SelectCommand = cmd
        adapter.Fill(ds, "Karyawan")

        cmd.CommandText = "SELECT * FROM kriteria"
        adapter.SelectCommand = cmd
        adapter.Fill(ds, "Kriteria")

        cmd.CommandText = "SELECT * FROM manajer"
        adapter.SelectCommand = cmd
        adapter.Fill(ds, "Manajer")

        cmd.CommandText = "SELECT * FROM penilaian"
        adapter.SelectCommand = cmd
        adapter.Fill(ds, "Penilaian")

        cmd.CommandText = "SELECT * FROM periode_penilaian"
        adapter.SelectCommand = cmd
        adapter.Fill(ds, "Periode_Penilaian")

        cmd.CommandText = "SELECT * FROM range_nilai"
        adapter.SelectCommand = cmd
        adapter.Fill(ds, "Range_Nilai")

        cmd.CommandText = "SELECT * FROM rekap_kehadiran"
        adapter.SelectCommand = cmd
        adapter.Fill(ds, "Rekap_Kehadiran")

        ds.WriteXml("Penilaian Per Karyawan.xml", XmlWriteMode.WriteSchema)

        ReportPenilaian21.SetParameterValue("Tahun", Val(Me.tahun))
        ReportPenilaian21.SetParameterValue("Karyawan", Me.karyawan)
        CrystalReportViewer1.ReportSource = ReportPenilaian21
        CrystalReportViewer1.Refresh()
    End Sub

End Class