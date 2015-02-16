Public Class FormPeriodePenilaian
    Private koneksi As KoneksiDB = New KoneksiDB()
    Private Sub FormPeriodePenilaian_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            koneksi.buka()
            reset()
        Catch ex As Exception
            MessageBox.Show(Me, "Terjadi kesalahan! Sumber: " & ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub reset()
        btnHapus.Visible = False
        btnSimpan.Text = "Simpan"
        txtId.Text = koneksi.generateId("PP", "periode_penilaian", "id_periode", 3)
        cbBulan1.Text = Nothing
        cbBulan2.Text = Nothing
        txtTahun.Text = Nothing
        txtKeterangan.Text = Nothing
        TabControl1.SelectedIndex = 0
        koneksi.isiDataGrid(dgvPeriodePenilaian, "periode_penilaian")
        dgvPeriodePenilaian.Columns(0).HeaderText = "ID"
        dgvPeriodePenilaian.Columns(1).HeaderText = "Bulan"
        dgvPeriodePenilaian.Columns(2).HeaderText = "Tahun"
        dgvPeriodePenilaian.Columns(3).HeaderText = "Keterangan"
    End Sub

    Private Sub btnKembali_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnKembali.Click
        Me.Close()
    End Sub

    Private Sub btnBatal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBatal.Click
        reset()
    End Sub

    Private Sub btnHapus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHapus.Click
        Try
            If MessageBox.Show(Me, "Yakin dihapus?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Dim query As String = "delete from periode_penilaian where id_periode = '" & txtId.Text & "'"
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

    Private Sub btnSimpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSimpan.Click
        Try
            Dim nama_periode As String = cbBulan1.Text & " - " & cbBulan2.Text
            If btnSimpan.Text = "Simpan" Then
                Dim query As String = "insert into periode_penilaian values('" & txtId.Text & "', '" & nama_periode & "', '" & txtTahun.Text & "', '" & txtKeterangan.Text & "')"
                Dim affectedRows = koneksi.nonQuery(query)
                If affectedRows > 0 Then
                    MessageBox.Show(Me, "Operasi berhasil dilakukan.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    reset()
                Else
                    MessageBox.Show(Me, "Operasi gagal dilakukan.", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            ElseIf btnSimpan.Text = "Ubah" Then
                Dim query As String = "update periode_penilaian set nama_periode = '" & nama_periode & "', tahun_periode = '" & txtTahun.Text & "', ket_periode = '" & txtKeterangan.Text & "' where id_periode = '" & txtId.Text & "'"
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

    Private Sub dgvPeriodePenilaian_CellContentDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPeriodePenilaian.CellContentDoubleClick
        Dim row As DataGridViewRow = dgvPeriodePenilaian.CurrentRow

        txtId.Text = row.Cells(0).Value
        Dim bulan As String = row.Cells(1).Value
        Dim bulanSpasi As String = bulan.Replace(" - ", " ")
        Dim bulanArray() As String = bulanSpasi.Split(" ")
        cbBulan1.Text = bulanArray(0)
        cbBulan2.Text = bulanArray(1)
        txtTahun.Text = row.Cells(2).Value
        txtKeterangan.Text = row.Cells(3).Value

        btnHapus.Visible = True
        btnSimpan.Text = "Ubah"

        TabControl1.SelectedIndex = 1
    End Sub

    Private Sub dgvPeriodePenilaian_RowHeaderMouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvPeriodePenilaian.RowHeaderMouseDoubleClick
        Dim row As DataGridViewRow = dgvPeriodePenilaian.CurrentRow

        txtId.Text = row.Cells(0).Value
        Dim bulan As String = row.Cells(1).Value
        Dim bulanSpasi As String = bulan.Replace(" - ", " ")
        Dim bulanArray() As String = bulanSpasi.Split(" ")
        cbBulan1.Text = bulanArray(0)
        cbBulan2.Text = bulanArray(1)
        txtTahun.Text = row.Cells(2).Value
        txtKeterangan.Text = row.Cells(3).Value
        
        btnHapus.Visible = True
        btnSimpan.Text = "Ubah"

        TabControl1.SelectedIndex = 1
    End Sub

    Private Sub txtTahun_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTahun.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
    End Sub
End Class