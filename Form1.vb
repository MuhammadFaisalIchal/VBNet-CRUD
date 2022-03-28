Imports System.Data.SqlClient

Public Class Form1
    ' Menaruh koneksi ke SQL di area publik agar bisa diakses dimanapun
    Dim con As New SqlConnection("Data Source=MF;Initial Catalog=ProgrammingDB;Persist Security Info=True;User ID=faisallocal;Password=faisallocal") ' String di dalam diambil dari properti koneksi

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadDataInGrid() ' Ditaro disini agar ketika Form nya ngeload, dia otomatis load data
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Mendeklarasikan variabel. Textproductid Diambil date properti name alias di Designer
        Dim pid As Integer = Textproductid.Text
        Dim iname As String = Textitemname.Text
        Dim design As String = Textdesign.Text
        Dim color As String = Combocolor.Text
        Dim insertdate As String = DateTimePickerinsert.Text
        ' Membuat logika if-else untuk RadioButton
        Dim wtype As String = ""
        If RadioAllowed.Checked = True Then
            wtype = "Allowed"
        Else
            wtype = "Not Allowed"
        End If

        'Melakukan koneksi ke SQL Server, memanggil class library dulu
        Dim con As New SqlConnection("Data Source=MF;Initial Catalog=ProgrammingDB;Persist Security Info=True;User ID=faisallocal;Password=faisallocal") ' String di dalam diambil dari properti koneksi
        con.Open()
        Dim command As New SqlCommand("Insert into Product_Setup_Tab values('" & pid & "', '" & iname & "', '" & design & "', '" & color & "', '" & insertdate & "', '" & wtype & "')", con) ' ('" & wtype & "') untuk membungkus variabel
        command.ExecuteNonQuery() ' Untuk melakukan operasi Insert, Update & Delete
        con.Close() ' Habis koneksi dibuka, harus ditutup
        MessageBox.Show("Successfully Inserted") ' Memberi pemberitahuan

        LoadDataInGrid() ' Untuk load data setelah di button click
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ' Mendeklarasikan variabel. Textproductid Diambil date properti name alias di Designer
        Dim pid As Integer = Textproductid.Text
        Dim iname As String = Textitemname.Text
        Dim design As String = Textdesign.Text
        Dim color As String = Combocolor.Text
        Dim insertdate As String = DateTimePickerinsert.Text
        ' Membuat logika if-else untuk RadioButton
        Dim wtype As String = ""
        If RadioAllowed.Checked = True Then
            wtype = "Allowed"
        Else
            wtype = "Not Allowed"
        End If

        'Melakukan koneksi ke SQL Server, memanggil class library dulu
        Dim con As New SqlConnection("Data Source=MF;Initial Catalog=ProgrammingDB;Persist Security Info=True;User ID=faisallocal;Password=faisallocal") ' String di dalam diambil dari properti koneksi
        con.Open()
        Dim command As New SqlCommand("update Product_Setup_Tab set ItemName = '" & iname & "', Design = '" & design & "', Color = '" & color & "', ItemDate = '" & insertdate & "', WarrantyType = '" & wtype & "' where Product_ID = '" & pid & "' ", con) ' ('" & wtype & "') untuk membungkus variabel
        command.ExecuteNonQuery() ' Untuk melakukan operasi Insert, Update & Delete
        con.Close() ' Habis koneksi dibuka, harus ditutup
        MessageBox.Show("Successfully Updated") ' Memberi pemberitahuan

        LoadDataInGrid() ' Untuk load data setelah di button click
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        ' Menambahkan konfirmasi hapus. Jika ya maka hapus, jika tidak jangan lakukan apapun
        If MessageBox.Show("Are you sure to delete?", "Delete Document", MessageBoxButtons.YesNo) = DialogResult.Yes Then
            Dim pid As Integer = Textproductid.Text
            con.Open()
            Dim command As New SqlCommand("delete from Product_Setup_Tab where Product_ID = '" & pid & "' ", con)
            command.ExecuteNonQuery()
            con.Close()
            MessageBox.Show("Successfully Deleted")

            LoadDataInGrid()

        End If
    End Sub

    ''' <summary>
    ''' Menambahkan metode untuk me-load data ke UI datagridview
    ''' </summary>
    Private Sub LoadDataInGrid() ' Sub apa?
        Dim command As New SqlCommand("select * from Product_Setup_Tab", con)
        Dim sda As New SqlDataAdapter(command)
        Dim dt As New DataTable
        sda.Fill(dt)
        DataGridView1.DataSource = dt ' DataGridView1 dari nama UI nya
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim pid As Integer = Textproductid.Text

        Dim command As New SqlCommand("select * from Product_Setup_Tab where Product_ID = '" & pid & "' ", con)
        Dim sda As New SqlDataAdapter(command)
        Dim dt As New DataTable
        sda.Fill(dt)
        DataGridView1.DataSource = dt ' DataGridView1 dari nama UI nya

    End Sub
End Class
