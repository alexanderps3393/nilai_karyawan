Public Class FormRekapKehadiran

    Private koneksi As KoneksiDB = New KoneksiDB()

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Me.Close()
    End Sub

    Private Sub reset()
        btnHapus.Visible = False
        btnSimpan.Text = "Simpan"
        txtId.Text = koneksi.generateId("RK", "rekap_kehadiran", "id_rekap", 5)
        txtCariKaryawan.Text = Nothing
        txtNamaKaryawan.Text = Nothing
        txtJenisKelamin.Text = Nothing
        txtAlamat.Text = Nothing
        cbPeriode1.Text = Nothing
        cbPeriode2.Text = Nothing
        txtTahunRekap.Text = Nothing
        dtpTanggalRekap.Value = Now()
        txtTerlambat.Text = Nothing
        txtAbsen.Text = Nothing
        txtSakit.Text = Nothing
        txtDepartemen.Text = Nothing
        txtGolongan.Text = Nothing
        koneksi.queryDataGrid(dgvRekap, "select id_rekap, a.id_karyawan, b.nama_karyawan, nama_rekap, tahun_rekap, tgl_rekap, terlambat, absen, sakit, jk_karyawan, alamat_karyawan, c.nama_departemen, d.nama_golongan from rekap_kehadiran a, karyawan b, departemen c, golongan d where a.id_karyawan = b.id_karyawan and b.id_departemen = c.id_departemen and b.id_golongan = d.id_golongan")

        'rename header column datagrid
        dgvRekap.Columns(0).HeaderText = "ID Rekap"
        dgvRekap.Columns(1).HeaderText = "ID Karyawan"
        dgvRekap.Columns(2).HeaderText = "Nama Karyawan"
        dgvRekap.Columns(3).HeaderText = "Periode"
        dgvRekap.Columns(4).HeaderText = "Tahun"
        dgvRekap.Columns(5).HeaderText = "Tanggal Rekap"
        dgvRekap.Columns(6).HeaderText = "Terlambat"
        dgvRekap.Columns(7).HeaderText = "Absen"
        dgvRekap.Columns(8).HeaderText = "Sakit"
        dgvRekap.Columns(9).Visible = False
        dgvRekap.Columns(10).Visible = False
        dgvRekap.Columns(11).Visible = False
        dgvRekap.Columns(12).Visible = False
        TabControl1.SelectedIndex = 0
    End Sub

    Private Sub FormRekapKehadiran_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            koneksi.buka()
            reset()
            Me.ToolTip1.SetToolTip(txtTerlambat, "Rata-rata jumlah hari terlambat dalam satu bulan dan/atau NO PUNCH")
            Me.ToolTip1.SetToolTip(txtAbsen, "Jumlah hari absen (dengan/tanpa surat pemberitahuan) dalam satu tahun")
            Me.ToolTip1.SetToolTip(txtSakit, "Jumlah hari sakit dalam satu tahun")
        Catch ex As Exception
            MessageBox.Show(Me, "Terjadi kesalahan!" & vbNewLine & "Sumber: " & ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnBatal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBatal.Click
        reset()
    End Sub

    Private Sub btnSimpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSimpan.Click
        Try
            Dim periode As String = cbPeriode1.Text & " - " & cbPeriode2.Text
            Dim tanggal As String = dtpTanggalRekap.Value.Year & "-" & dtpTanggalRekap.Value.Month & "-" & dtpTanggalRekap.Value.Day
            If btnSimpan.Text = "Simpan" Then
                Dim query As String = "insert into rekap_kehadiran values('" & txtId.Text & "', '" & txtCariKaryawan.Text & "', '" & periode & "', '" & txtTahunRekap.Text & "', '" & tanggal & "', '" & txtTerlambat.Text & "', '" & txtAbsen.Text & "', '" & txtSakit.Text & "')"
                Dim affectedRows = koneksi.nonQuery(query)
                If affectedRows > 0 Then
                    MessageBox.Show(Me, "Operasi berhasil dilakukan.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    reset()
                Else
                    MessageBox.Show(Me, "Operasi gagal dilakukan.", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            ElseIf btnSimpan.Text = "Ubah" Then
                Dim query As String = "update rekap_kehadiran set id_karyawan = '" & txtCariKaryawan.Text & "', nama_rekap = '" & periode & "', tahun_rekap = '" & txtTahunRekap.Text & "', tgl_rekap = '" & tanggal & "', terlambat = '" & txtTerlambat.Text & "', absen = '" & txtAbsen.Text & "', sakit = '" & txtSakit.Text & "' where id_rekap = '" & txtId.Text & "'"
                Dim affectedRows = koneksi.nonQuery(query)
                If affectedRows > 0 Then
                    MessageBox.Show(Me, "Operasi berhasil dilakukan.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    reset()
                Else
                    MessageBox.Show(Me, "Operasi gagal dilakukan.", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(Me, "Terjadi kesalahan!" & vbNewLine & "Sumber: " & ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnHapus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHapus.Click
        Try
            If MessageBox.Show(Me, "Yakin dihapus?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Dim query As String = "delete from rekap_kehadiran where id_rekap = '" & txtId.Text & "'"
                Dim affectedRows = koneksi.nonQuery(query)
                If affectedRows > 0 Then
                    MessageBox.Show(Me, "Operasi berhasil dilakukan.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    reset()
                Else
                    MessageBox.Show(Me, "Operasi gagal dilakukan.", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(Me, "Terjadi kesalahan!" & vbNewLine & "Sumber: " & ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgvRekap_CellContentDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvRekap.CellContentDoubleClick
        Dim row As DataGridViewRow = dgvRekap.CurrentRow

        txtId.Text = row.Cells(0).Value
        txtCariKaryawan.Text = row.Cells(1).Value
        txtNamaKaryawan.Text = row.Cells(2).Value
        Dim bulan As String = row.Cells(3).Value
        Dim bulanSpasi As String = bulan.Replace(" - ", " ")
        Dim bulanArray() As String = bulanSpasi.Split(" ")
        cbPeriode1.Text = bulanArray(0)
        cbPeriode2.Text = bulanArray(1)
        txtTahunRekap.Text = row.Cells(4).Value
        dtpTanggalRekap.Text = row.Cells(5).Value
        txtTerlambat.Text = row.Cells(6).Value
        txtAbsen.Text = row.Cells(7).Value
        txtSakit.Text = row.Cells(8).Value
        If row.Cells(9).Value = "L" Then
            txtJenisKelamin.Text = "Laki-laki"
        Else
            txtJenisKelamin.Text = "Perempuan"
        End If
        txtAlamat.Text = row.Cells(10).Value
        txtDepartemen.Text = row.Cells(11).Value
        txtGolongan.Text = row.Cells(12).Value

        btnHapus.Visible = True
        btnSimpan.Text = "Ubah"

        TabControl1.SelectedIndex = 1
    End Sub

    Private Sub dgvRekap_RowHeaderMouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvRekap.RowHeaderMouseDoubleClick
        Dim row As DataGridViewRow = dgvRekap.CurrentRow

        txtId.Text = row.Cells(0).Value
        txtCariKaryawan.Text = row.Cells(1).Value
        txtNamaKaryawan.Text = row.Cells(2).Value
        Dim bulan As String = row.Cells(3).Value
        Dim bulanSpasi As String = bulan.Replace(" - ", " ")
        Dim bulanArray() As String = bulanSpasi.Split(" ")
        cbPeriode1.Text = bulanArray(0)
        cbPeriode2.Text = bulanArray(1)
        txtTahunRekap.Text = row.Cells(4).Value
        dtpTanggalRekap.Text = row.Cells(5).Value
        txtTerlambat.Text = row.Cells(6).Value
        txtAbsen.Text = row.Cells(7).Value
        txtSakit.Text = row.Cells(8).Value
        If row.Cells(9).Value = "L" Then
            txtJenisKelamin.Text = "Laki-laki"
        Else
            txtJenisKelamin.Text = "Perempuan"
        End If
        txtAlamat.Text = row.Cells(10).Value
        txtDepartemen.Text = row.Cells(11).Value
        txtGolongan.Text = row.Cells(12).Value

        btnHapus.Visible = True
        btnSimpan.Text = "Ubah"

        TabControl1.SelectedIndex = 1
    End Sub

    Private Sub btnCari_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCari.Click
        Dim cariKaryawan As New DialogCariKaryawan
        Dim hasil As DialogResult = cariKaryawan.ShowDialog(Me)
        If hasil = Windows.Forms.DialogResult.OK Then
            txtCariKaryawan.Text = cariKaryawan.id
            txtNamaKaryawan.Text = cariKaryawan.nama
            txtDepartemen.Text = cariKaryawan.departemen
            txtGolongan.Text = cariKaryawan.golongan
            If cariKaryawan.jk = "L" Then
                txtJenisKelamin.Text = "Laki-laki"
            Else
                txtJenisKelamin.Text = "Perempuan"
            End If
            txtAlamat.Text = cariKaryawan.alamat
        End If
    End Sub

    Private Sub txtTahunRekap_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTahunRekap.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
    End Sub

    Private Sub txtTerlambat_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTerlambat.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
    End Sub

    Private Sub txtAbsen_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAbsen.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
    End Sub

    Private Sub txtSakit_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSakit.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
    End Sub
End Class