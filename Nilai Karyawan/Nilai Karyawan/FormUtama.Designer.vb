<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormUtama
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormUtama))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.tabControl1 = New System.Windows.Forms.TabControl()
        Me.tabPage1 = New System.Windows.Forms.TabPage()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.btnPeriode = New System.Windows.Forms.Button()
        Me.btnKriteria = New System.Windows.Forms.Button()
        Me.btnRangeNilai = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnGolongan = New System.Windows.Forms.Button()
        Me.btnDepartemen = New System.Windows.Forms.Button()
        Me.btnKaryawan = New System.Windows.Forms.Button()
        Me.btnKehadiran = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnDashboard = New System.Windows.Forms.Button()
        Me.tabPage2 = New System.Windows.Forms.TabPage()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.btnProses = New System.Windows.Forms.Button()
        Me.tabPage3 = New System.Windows.Forms.TabPage()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.btnLaporan1 = New System.Windows.Forms.Button()
        Me.btnLaporanAll = New System.Windows.Forms.Button()
        Me.tabPage4 = New System.Windows.Forms.TabPage()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.btnAkun = New System.Windows.Forms.Button()
        Me.panel2 = New System.Windows.Forms.Panel()
        Me.toolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.statusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.tssUsername = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tssLevel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tssDatabase = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tssTanggal = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Panel1.SuspendLayout()
        Me.tabControl1.SuspendLayout()
        Me.tabPage1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.tabPage2.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.tabPage3.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.tabPage4.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.statusStrip1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.Maroon
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(885, 50)
        Me.Panel1.TabIndex = 0
        '
        'tabControl1
        '
        Me.tabControl1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tabControl1.Controls.Add(Me.tabPage1)
        Me.tabControl1.Controls.Add(Me.tabPage2)
        Me.tabControl1.Controls.Add(Me.tabPage3)
        Me.tabControl1.Controls.Add(Me.tabPage4)
        Me.tabControl1.ItemSize = New System.Drawing.Size(60, 25)
        Me.tabControl1.Location = New System.Drawing.Point(0, 50)
        Me.tabControl1.Name = "tabControl1"
        Me.tabControl1.SelectedIndex = 0
        Me.tabControl1.Size = New System.Drawing.Size(884, 142)
        Me.tabControl1.TabIndex = 3
        '
        'tabPage1
        '
        Me.tabPage1.Controls.Add(Me.GroupBox3)
        Me.tabPage1.Controls.Add(Me.GroupBox2)
        Me.tabPage1.Controls.Add(Me.GroupBox1)
        Me.tabPage1.Location = New System.Drawing.Point(4, 29)
        Me.tabPage1.Name = "tabPage1"
        Me.tabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPage1.Size = New System.Drawing.Size(876, 109)
        Me.tabPage1.TabIndex = 0
        Me.tabPage1.Text = "Data"
        Me.tabPage1.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.btnPeriode)
        Me.GroupBox3.Controls.Add(Me.btnKriteria)
        Me.GroupBox3.Controls.Add(Me.btnRangeNilai)
        Me.GroupBox3.Location = New System.Drawing.Point(413, 6)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(235, 97)
        Me.GroupBox3.TabIndex = 5
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Penilaian"
        '
        'btnPeriode
        '
        Me.btnPeriode.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnPeriode.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPeriode.Image = Global.Nilai_Karyawan.My.Resources.Resources.icon_0322
        Me.btnPeriode.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnPeriode.Location = New System.Drawing.Point(158, 18)
        Me.btnPeriode.Name = "btnPeriode"
        Me.btnPeriode.Size = New System.Drawing.Size(70, 73)
        Me.btnPeriode.TabIndex = 3
        Me.btnPeriode.Text = "&Periode Penilaian"
        Me.btnPeriode.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnPeriode.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnPeriode.UseVisualStyleBackColor = True
        '
        'btnKriteria
        '
        Me.btnKriteria.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnKriteria.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnKriteria.Image = Global.Nilai_Karyawan.My.Resources.Resources.icon_0323
        Me.btnKriteria.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnKriteria.Location = New System.Drawing.Point(6, 18)
        Me.btnKriteria.Name = "btnKriteria"
        Me.btnKriteria.Size = New System.Drawing.Size(70, 73)
        Me.btnKriteria.TabIndex = 1
        Me.btnKriteria.Text = "Kr&iteria"
        Me.btnKriteria.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnKriteria.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnKriteria.UseVisualStyleBackColor = True
        '
        'btnRangeNilai
        '
        Me.btnRangeNilai.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnRangeNilai.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRangeNilai.Image = Global.Nilai_Karyawan.My.Resources.Resources.icon_0321
        Me.btnRangeNilai.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnRangeNilai.Location = New System.Drawing.Point(82, 18)
        Me.btnRangeNilai.Name = "btnRangeNilai"
        Me.btnRangeNilai.Size = New System.Drawing.Size(70, 73)
        Me.btnRangeNilai.TabIndex = 2
        Me.btnRangeNilai.Text = "Range &Nilai"
        Me.btnRangeNilai.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnRangeNilai.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnRangeNilai.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnGolongan)
        Me.GroupBox2.Controls.Add(Me.btnDepartemen)
        Me.GroupBox2.Controls.Add(Me.btnKaryawan)
        Me.GroupBox2.Controls.Add(Me.btnKehadiran)
        Me.GroupBox2.Location = New System.Drawing.Point(94, 6)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(313, 97)
        Me.GroupBox2.TabIndex = 4
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Karyawan"
        '
        'btnGolongan
        '
        Me.btnGolongan.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnGolongan.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGolongan.Image = Global.Nilai_Karyawan.My.Resources.Resources.icon_03210
        Me.btnGolongan.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnGolongan.Location = New System.Drawing.Point(234, 18)
        Me.btnGolongan.Name = "btnGolongan"
        Me.btnGolongan.Size = New System.Drawing.Size(70, 73)
        Me.btnGolongan.TabIndex = 4
        Me.btnGolongan.Text = "&Golongan"
        Me.btnGolongan.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnGolongan.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnGolongan.UseVisualStyleBackColor = True
        '
        'btnDepartemen
        '
        Me.btnDepartemen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnDepartemen.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDepartemen.Image = Global.Nilai_Karyawan.My.Resources.Resources.icon_032a
        Me.btnDepartemen.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnDepartemen.Location = New System.Drawing.Point(158, 18)
        Me.btnDepartemen.Name = "btnDepartemen"
        Me.btnDepartemen.Size = New System.Drawing.Size(70, 73)
        Me.btnDepartemen.TabIndex = 3
        Me.btnDepartemen.Text = "D&epartemen"
        Me.btnDepartemen.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnDepartemen.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnDepartemen.UseVisualStyleBackColor = True
        '
        'btnKaryawan
        '
        Me.btnKaryawan.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnKaryawan.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnKaryawan.Image = Global.Nilai_Karyawan.My.Resources.Resources.icon_0325
        Me.btnKaryawan.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnKaryawan.Location = New System.Drawing.Point(6, 18)
        Me.btnKaryawan.Name = "btnKaryawan"
        Me.btnKaryawan.Size = New System.Drawing.Size(70, 73)
        Me.btnKaryawan.TabIndex = 1
        Me.btnKaryawan.Text = "&Karyawan"
        Me.btnKaryawan.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnKaryawan.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnKaryawan.UseVisualStyleBackColor = True
        '
        'btnKehadiran
        '
        Me.btnKehadiran.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnKehadiran.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnKehadiran.Image = Global.Nilai_Karyawan.My.Resources.Resources.icon_0324
        Me.btnKehadiran.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnKehadiran.Location = New System.Drawing.Point(82, 18)
        Me.btnKehadiran.Name = "btnKehadiran"
        Me.btnKehadiran.Size = New System.Drawing.Size(70, 73)
        Me.btnKehadiran.TabIndex = 2
        Me.btnKehadiran.Text = "&Rekap Kehadiran"
        Me.btnKehadiran.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnKehadiran.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnKehadiran.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnDashboard)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(82, 97)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Home"
        '
        'btnDashboard
        '
        Me.btnDashboard.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDashboard.Image = Global.Nilai_Karyawan.My.Resources.Resources.icon_0326
        Me.btnDashboard.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnDashboard.Location = New System.Drawing.Point(6, 18)
        Me.btnDashboard.Name = "btnDashboard"
        Me.btnDashboard.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnDashboard.Size = New System.Drawing.Size(70, 73)
        Me.btnDashboard.TabIndex = 0
        Me.btnDashboard.Text = "&Dashboard"
        Me.btnDashboard.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnDashboard.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnDashboard.UseVisualStyleBackColor = True
        '
        'tabPage2
        '
        Me.tabPage2.Controls.Add(Me.GroupBox5)
        Me.tabPage2.Location = New System.Drawing.Point(4, 29)
        Me.tabPage2.Name = "tabPage2"
        Me.tabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPage2.Size = New System.Drawing.Size(876, 109)
        Me.tabPage2.TabIndex = 1
        Me.tabPage2.Text = "Penilaian"
        Me.tabPage2.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.btnProses)
        Me.GroupBox5.Location = New System.Drawing.Point(9, 7)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(84, 97)
        Me.GroupBox5.TabIndex = 0
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Penilaian"
        '
        'btnProses
        '
        Me.btnProses.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnProses.Image = Global.Nilai_Karyawan.My.Resources.Resources.icon_0328
        Me.btnProses.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnProses.Location = New System.Drawing.Point(6, 18)
        Me.btnProses.Name = "btnProses"
        Me.btnProses.Size = New System.Drawing.Size(70, 73)
        Me.btnProses.TabIndex = 0
        Me.btnProses.Text = "Pro&ses"
        Me.btnProses.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnProses.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnProses.UseVisualStyleBackColor = True
        '
        'tabPage3
        '
        Me.tabPage3.Controls.Add(Me.GroupBox6)
        Me.tabPage3.Location = New System.Drawing.Point(4, 29)
        Me.tabPage3.Name = "tabPage3"
        Me.tabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPage3.Size = New System.Drawing.Size(876, 109)
        Me.tabPage3.TabIndex = 2
        Me.tabPage3.Text = "Laporan"
        Me.tabPage3.UseVisualStyleBackColor = True
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.btnLaporan1)
        Me.GroupBox6.Controls.Add(Me.btnLaporanAll)
        Me.GroupBox6.Location = New System.Drawing.Point(7, 7)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(161, 97)
        Me.GroupBox6.TabIndex = 0
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Laporan"
        '
        'btnLaporan1
        '
        Me.btnLaporan1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLaporan1.Image = Global.Nilai_Karyawan.My.Resources.Resources.icon_032a1
        Me.btnLaporan1.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnLaporan1.Location = New System.Drawing.Point(82, 18)
        Me.btnLaporan1.Name = "btnLaporan1"
        Me.btnLaporan1.Size = New System.Drawing.Size(70, 73)
        Me.btnLaporan1.TabIndex = 2
        Me.btnLaporan1.Text = "&Per Karyawan"
        Me.btnLaporan1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnLaporan1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnLaporan1.UseVisualStyleBackColor = True
        '
        'btnLaporanAll
        '
        Me.btnLaporanAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLaporanAll.Image = Global.Nilai_Karyawan.My.Resources.Resources.icon_0329
        Me.btnLaporanAll.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnLaporanAll.Location = New System.Drawing.Point(6, 18)
        Me.btnLaporanAll.Name = "btnLaporanAll"
        Me.btnLaporanAll.Size = New System.Drawing.Size(70, 73)
        Me.btnLaporanAll.TabIndex = 1
        Me.btnLaporanAll.Text = "&Keseluruhan"
        Me.btnLaporanAll.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnLaporanAll.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnLaporanAll.UseVisualStyleBackColor = True
        '
        'tabPage4
        '
        Me.tabPage4.Controls.Add(Me.GroupBox4)
        Me.tabPage4.Location = New System.Drawing.Point(4, 29)
        Me.tabPage4.Name = "tabPage4"
        Me.tabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPage4.Size = New System.Drawing.Size(876, 109)
        Me.tabPage4.TabIndex = 3
        Me.tabPage4.Text = "Pengaturan"
        Me.tabPage4.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.btnAkun)
        Me.GroupBox4.Location = New System.Drawing.Point(8, 6)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(83, 97)
        Me.GroupBox4.TabIndex = 4
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Akun"
        '
        'btnAkun
        '
        Me.btnAkun.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnAkun.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAkun.Image = Global.Nilai_Karyawan.My.Resources.Resources.icon_0327
        Me.btnAkun.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnAkun.Location = New System.Drawing.Point(6, 18)
        Me.btnAkun.Name = "btnAkun"
        Me.btnAkun.Size = New System.Drawing.Size(70, 73)
        Me.btnAkun.TabIndex = 0
        Me.btnAkun.Text = "&Pengguna"
        Me.btnAkun.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnAkun.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnAkun.UseVisualStyleBackColor = True
        '
        'panel2
        '
        Me.panel2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panel2.AutoScroll = True
        Me.panel2.BackColor = System.Drawing.SystemColors.ControlDark
        Me.panel2.Location = New System.Drawing.Point(0, 194)
        Me.panel2.Name = "panel2"
        Me.panel2.Size = New System.Drawing.Size(884, 443)
        Me.panel2.TabIndex = 4
        '
        'statusStrip1
        '
        Me.statusStrip1.BackColor = System.Drawing.Color.White
        Me.statusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssUsername, Me.tssLevel, Me.tssDatabase, Me.tssTanggal})
        Me.statusStrip1.Location = New System.Drawing.Point(0, 637)
        Me.statusStrip1.Name = "statusStrip1"
        Me.statusStrip1.Size = New System.Drawing.Size(884, 24)
        Me.statusStrip1.TabIndex = 5
        Me.statusStrip1.Text = "statusStrip1"
        '
        'tssUsername
        '
        Me.tssUsername.AutoToolTip = True
        Me.tssUsername.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.tssUsername.Name = "tssUsername"
        Me.tssUsername.Size = New System.Drawing.Size(78, 19)
        Me.tssUsername.Text = "tssUsername"
        Me.tssUsername.ToolTipText = "Nama Manajer"
        '
        'tssLevel
        '
        Me.tssLevel.AutoToolTip = True
        Me.tssLevel.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.tssLevel.Name = "tssLevel"
        Me.tssLevel.Size = New System.Drawing.Size(52, 19)
        Me.tssLevel.Text = "tssLevel"
        Me.tssLevel.ToolTipText = "NIP"
        '
        'tssDatabase
        '
        Me.tssDatabase.AutoToolTip = True
        Me.tssDatabase.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.tssDatabase.Name = "tssDatabase"
        Me.tssDatabase.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.tssDatabase.Size = New System.Drawing.Size(73, 19)
        Me.tssDatabase.Text = "tssDatabase"
        Me.tssDatabase.ToolTipText = "Database"
        '
        'tssTanggal
        '
        Me.tssTanggal.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.tssTanggal.Name = "tssTanggal"
        Me.tssTanggal.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.tssTanggal.Size = New System.Drawing.Size(666, 19)
        Me.tssTanggal.Spring = True
        Me.tssTanggal.Text = "tssTanggal"
        Me.tssTanggal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Timer1
        '
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImage = Global.Nilai_Karyawan.My.Resources.Resources.kewledits_weebly__120_
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox1.Location = New System.Drawing.Point(3, 3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(247, 44)
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'FormUtama
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(884, 661)
        Me.Controls.Add(Me.statusStrip1)
        Me.Controls.Add(Me.panel2)
        Me.Controls.Add(Me.tabControl1)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(800, 600)
        Me.Name = "FormUtama"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Aplikasi Penilaian Kinerja Karyawan"
        Me.Panel1.ResumeLayout(False)
        Me.tabControl1.ResumeLayout(False)
        Me.tabPage1.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.tabPage2.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.tabPage3.ResumeLayout(False)
        Me.GroupBox6.ResumeLayout(False)
        Me.tabPage4.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.statusStrip1.ResumeLayout(False)
        Me.statusStrip1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Private WithEvents tabControl1 As System.Windows.Forms.TabControl
    Private WithEvents tabPage1 As System.Windows.Forms.TabPage
    Private WithEvents btnDashboard As System.Windows.Forms.Button
    Private WithEvents tabPage2 As System.Windows.Forms.TabPage
    Private WithEvents tabPage3 As System.Windows.Forms.TabPage
    Private WithEvents tabPage4 As System.Windows.Forms.TabPage
    Private WithEvents panel2 As System.Windows.Forms.Panel
    Private WithEvents toolTip1 As System.Windows.Forms.ToolTip
    Private WithEvents statusStrip1 As System.Windows.Forms.StatusStrip
    Private WithEvents tssUsername As System.Windows.Forms.ToolStripStatusLabel
    Private WithEvents tssLevel As System.Windows.Forms.ToolStripStatusLabel
    Private WithEvents tssDatabase As System.Windows.Forms.ToolStripStatusLabel
    Private WithEvents btnKehadiran As System.Windows.Forms.Button
    Private WithEvents btnKaryawan As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Private WithEvents btnKriteria As System.Windows.Forms.Button
    Private WithEvents btnRangeNilai As System.Windows.Forms.Button
    Private WithEvents btnPeriode As System.Windows.Forms.Button
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Private WithEvents btnAkun As System.Windows.Forms.Button
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents tssTanggal As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents btnProses As System.Windows.Forms.Button
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents btnLaporanAll As System.Windows.Forms.Button
    Friend WithEvents btnLaporan1 As System.Windows.Forms.Button
    Private WithEvents btnGolongan As System.Windows.Forms.Button
    Private WithEvents btnDepartemen As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
End Class
