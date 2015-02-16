Public Class FormUtama

    Private database, username, nip As String

    Public Sub setDatabase(ByVal db As String)
        Me.database = db
    End Sub

    Public Sub setUsername(ByVal user As String)
        Me.username = user
    End Sub

    Public Sub setNip(ByVal nip As String)
        Me.nip = nip
    End Sub

    Private Sub FormUtama_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        tssUsername.Text = Me.username
        tssLevel.Text = Me.nip
        tssDatabase.Text = Me.database

        isiTooltip()
        Timer1.Enabled = True
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        tssTanggal.Text = Date.Now.ToString("dd MMMM yyyy hh:mm:ss")
    End Sub

    Private Sub FormUtama_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Application.Exit()
    End Sub

    Private Sub FormUtama_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If MessageBox.Show(Me, "Keluar dari aplikasi?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
            e.Cancel = True
        End If
    End Sub

    Private Sub isiTooltip()
        Me.toolTip1.SetToolTip(Me.btnDashboard, "Dashboard")
        Me.toolTip1.SetToolTip(Me.btnKaryawan, "Karyawan")
        Me.toolTip1.SetToolTip(Me.btnKehadiran, "Rekap Kehadiran")
        Me.toolTip1.SetToolTip(Me.btnKriteria, "Kriteria Penilaian")
        Me.toolTip1.SetToolTip(Me.btnRangeNilai, "Range Nilai")
        Me.toolTip1.SetToolTip(Me.btnPeriode, "Periode Penilaian")
        Me.toolTip1.SetToolTip(Me.btnAkun, "Pengaturan Akun Pengguna")
        Me.toolTip1.SetToolTip(Me.btnProses, "Proses Penilaian")
        Me.toolTip1.SetToolTip(Me.btnLaporanAll, "Rekap Penilaian Karyawan")
        Me.toolTip1.SetToolTip(Me.btnLaporan1, "Detil Penilaian Karyawan")
        Me.toolTip1.SetToolTip(Me.btnDepartemen, "Departemen")
        Me.toolTip1.SetToolTip(Me.btnGolongan, "Golongan")
    End Sub

    Private Sub btnDashboard_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDashboard.Click
        panel2.Controls.Clear()
        Dim dashboard As FormDashboard = New FormDashboard
        dashboard.TopLevel = False
        dashboard.AutoScroll = True
        panel2.Controls.Add(dashboard)
        dashboard.Dock = DockStyle.Fill
        dashboard.Show()
    End Sub

    Private Sub btnKaryawan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnKaryawan.Click
        panel2.Controls.Clear()
        Dim karyawan As FormKaryawan = New FormKaryawan
        karyawan.TopLevel = False
        karyawan.AutoScroll = True
        panel2.Controls.Add(karyawan)
        karyawan.Dock = DockStyle.Fill
        karyawan.Show()
    End Sub

    Private Sub btnKehadiran_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnKehadiran.Click
        panel2.Controls.Clear()
        Dim rekap As FormRekapKehadiran = New FormRekapKehadiran
        rekap.TopLevel = False
        rekap.AutoScroll = True
        panel2.Controls.Add(rekap)
        rekap.Dock = DockStyle.Fill
        rekap.Show()
    End Sub

    Private Sub btnKriteria_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnKriteria.Click
        panel2.Controls.Clear()
        Dim kriteria As FormKriteria = New FormKriteria
        kriteria.TopLevel = False
        kriteria.AutoScroll = True
        panel2.Controls.Add(kriteria)
        kriteria.Dock = DockStyle.Fill
        kriteria.Show()
    End Sub

    Private Sub btnRangeNilai_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRangeNilai.Click
        panel2.Controls.Clear()
        Dim range As FormRangeNilai = New FormRangeNilai
        range.TopLevel = False
        range.AutoScroll = True
        panel2.Controls.Add(range)
        range.Dock = DockStyle.Fill
        range.Show()
    End Sub

    Private Sub btnPeriode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPeriode.Click
        panel2.Controls.Clear()
        Dim periode As FormPeriodePenilaian = New FormPeriodePenilaian
        periode.TopLevel = False
        periode.AutoScroll = True
        panel2.Controls.Add(periode)
        periode.Dock = DockStyle.Fill
        periode.Show()
    End Sub

    Private Sub btnDepartemen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDepartemen.Click
        panel2.Controls.Clear()
        Dim departemen As FormDepartemen = New FormDepartemen
        departemen.TopLevel = False
        departemen.AutoScroll = True
        panel2.Controls.Add(departemen)
        departemen.Dock = DockStyle.Fill
        departemen.Show()
    End Sub

    Private Sub btnGolongan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGolongan.Click
        panel2.Controls.Clear()
        Dim golongan As FormGolongan = New FormGolongan
        golongan.TopLevel = False
        golongan.AutoScroll = True
        panel2.Controls.Add(golongan)
        golongan.Dock = DockStyle.Fill
        golongan.Show()
    End Sub

    Private Sub btnProses_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProses.Click
        panel2.Controls.Clear()
        Dim penilaian As FormPrePenilaian = New FormPrePenilaian
        penilaian.TopLevel = False
        penilaian.AutoScroll = True
        penilaian.SetNIP(Me.nip)
        panel2.Controls.Add(penilaian)
        penilaian.Dock = DockStyle.Fill
        penilaian.Show()
    End Sub

    Private Sub btnAkun_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAkun.Click
        panel2.Controls.Clear()
        Dim pengguna As FormPengguna = New FormPengguna
        pengguna.TopLevel = False
        pengguna.AutoScroll = True
        pengguna.SetNip(Me.nip)
        pengguna.SetNama(Me.username)
        panel2.Controls.Add(pengguna)
        pengguna.Dock = DockStyle.Fill
        pengguna.Show()
    End Sub

    Private Sub btnLaporanAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLaporanAll.Click
        panel2.Controls.Clear()
        Dim filter As New FormFilter1
        filter.TopLevel = False
        filter.AutoScroll = True
        panel2.Controls.Add(filter)
        filter.Dock = DockStyle.Fill
        filter.SetManajer(tssUsername.Text)
        filter.Show()
    End Sub

    Private Sub btnLaporan1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLaporan1.Click
        panel2.Controls.Clear()
        Dim laporan As New FormFilter2
        laporan.TopLevel = False
        laporan.AutoScroll = True
        panel2.Controls.Add(laporan)
        laporan.Dock = DockStyle.Fill
        laporan.Show()
    End Sub
End Class