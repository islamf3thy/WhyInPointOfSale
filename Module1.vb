Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.IO
Module Module1
    Public SQLconn As New SqlClient.SqlConnection
    'Dim INI_File As New IniFile(My.Application.Info.DirectoryPath + "/GetPath.ini")
    'Public SearchFlg As Integer
    'Public VALX As Integer
    'Public Stspec, Minutes As Integer
    'Public istlam = False
    Public RowIndex As Integer
    'Public unt As Integer
    'Public uitpriceflg As Integer
    'Public editperm, certpern As Boolean
    'Public clasop As Integer
    'Public currnetuser As Integer
    'Public NOTOKROWS As Integer
    Public frmOp, Current_User As Integer
    Public eos As Integer = 0
    Public mylist2 As String
    Public User_Table As New DataTable
  

    'Public Function con() As SqlConnection
    '    Try
    '        '''' settings في حال لم يتم تخزين اي قيمه في
    '        If My.Settings.sern = "" And My.Settings.datan = "" And My.Settings.un = "" And My.Settings.pn = "" And My.Settings.tn = "" Then
    '            ConnectionMode.ShowDialog()
    '            Return New SqlConnection
    '            '''' اتصال من خلال ملف خارجي''''
    '        ElseIf My.Settings.tn <> "" And My.Settings.sern = "" And My.Settings.datan = "" And My.Settings.un = "" And My.Settings.pn = "" Then
    '            Dim red As New StreamReader(My.Settings.tn)
    '            Form1.Text = "  متصل من خلال ملف خارجي" '' هذا السطر للتوضيح فقط يمكن الاسغناء عنه
    '            Return New SqlConnection(red.ReadToEnd)
    '            '''' windows authenticationاتصال من خلال ''''
    '        ElseIf My.Settings.un = "" And My.Settings.pn = "" And My.Settings.tn = "" And My.Settings.sern <> "" And My.Settings.datan <> "" Then
    '            Dim sql As String = " Server='" & My.Settings.sern & "';Database='" & My.Settings.datan & "';integrated security=true"
    '            Dim coo As New SqlConnection(sql)
    '            Form1.Text = "متصل windows authentication "  '' هذا السطر للتوضيح فقط يمكن الاسغناء عنه
    '            Return New SqlConnection(sql)
    '            '''' sqlserver authentication اتصال من خلال ''''
    '        ElseIf My.Settings.sern <> "" And My.Settings.datan <> "" And My.Settings.un <> "" And My.Settings.pn <> "" And My.Settings.tn = "" Then
    '            Dim sql2 As String = " Server='" & My.Settings.sern & "';Database='" & My.Settings.datan & "';User Id='" & My.Settings.un & "';Password='" & My.Settings.pn & "'"
    '            Dim coo As New SqlConnection(sql2)
    '            Form1.Text = "متصل sql server authentication"  '' هذا السطر للتوضيح فقط يمكن الاسغناء عنه
    '            Return New SqlConnection(sql2)
    '        Else
    '            Return New SqlConnection
    '        End If
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message, "فشل ف عملية الاتصال", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
    '        SQLconn.Close()
    '        End
    '    End Try

    'End Function

    Public Sub OPENCONNECTION()
        If SQLconn.State = 1 Then SQLconn.Close()
        Try

            '''' windows authenticationاتصال من خلال ''''
            If My.Settings.un = "" And My.Settings.pn = "" And My.Settings.tn = "" And My.Settings.sern <> "" And My.Settings.datan <> "" Then
                SQLconn.ConnectionString = " Server='" & My.Settings.sern & "';Database='" & My.Settings.datan & "';integrated security=true"
                SQLconn.Open()
                '''' sqlserver authentication اتصال من خلال ''''
            ElseIf My.Settings.sern <> "" And My.Settings.datan <> "" And My.Settings.un <> "" And My.Settings.pn <> "" And My.Settings.tn = "" Then
                SQLconn.ConnectionString = " Server='" & My.Settings.sern & "';Database='" & My.Settings.datan & "';User Id='" & My.Settings.un & "';Password='" & My.Settings.pn & "'"
                SQLconn.Open()
                '''' اتصال من خلال ملف خارجي''''
            ElseIf My.Settings.tn <> "" And My.Settings.sern = "" And My.Settings.datan = "" And My.Settings.un = "" And My.Settings.pn = "" Then
                Dim red As New StreamReader(My.Settings.tn)
                red.ReadToEnd()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "فشل ف عملية الاتصال", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            SQLconn.Close()
            End
        End Try
    End Sub
    Public Sub PuFillDataGridView(ByVal MyDataGridView As DataGridView, ByVal sqlstr As String)

        MyDataGridView.DataSource = Nothing
        Dim adp As New SqlClient.SqlDataAdapter(sqlstr, SQLconn)
        Dim ds As New DataSet
        adp.Fill(ds)
        Dim dt = ds.Tables(0)
        '========================================
        MyDataGridView.AutoGenerateColumns = False
        MyDataGridView.DataSource = dt.DefaultView

        MyDataGridView.ColumnHeadersDefaultCellStyle.Font = New Font("Tahoma", 9, FontStyle.Regular, GraphicsUnit.Point)
        MyDataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single
        MyDataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        MyDataGridView.DefaultCellStyle.Font = New Font("Tahoma", 8, FontStyle.Regular, GraphicsUnit.Point)

        '=======================================
    End Sub
    'Public Sub OPENCONNECTION()
    '    If SQLconn.State = 1 Then SQLconn.Close()
    '    Try
    '        SQLconn.ConnectionString = "Data Source=.;Initial Catalog=SalesSystem_db;Integrated Security=True"
    '        SQLconn.Open()
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message, "فشل ف عملية الاتصال", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
    '        SQLconn.Close()
    '        End
    '    End Try
    'End Sub
    Function GET_LAST_RECORD(ByVal TableName, ByVal OrderbyFiled) As Integer
        GET_LAST_RECORD = 0
        Dim STR = "select * from " & TableName & " Order by " & OrderbyFiled
        Dim Adp = New SqlClient.SqlDataAdapter(STR, SQLconn)
        Dim DS = New DataSet
        Adp.Fill(DS)
        Dim DT As DataTable
        DT = DS.Tables(0)
        If DT.Rows.Count <> 0 Then
            Dim i = DT.Rows.Count - 1
            GET_LAST_RECORD = Val(DT.Rows(i).Item(OrderbyFiled))
        End If
    End Function

    Public Function SetSupplierTrans(SupplierName, VoucherType, VoucherCode, VoucherDate, VoucherDescriotion, VoucherDebit, VoucherCredit) As Boolean
        SetSupplierTrans = False
        Try
            Dim adp = New SqlClient.SqlDataAdapter("select * from SupplierTrans", SQLconn)
            Dim ds = New DataSet
            adp.Fill(ds)
            Dim dt = ds.Tables(0)
            Dim dr = dt.NewRow
            dr!SupplierName = SupplierName
            dr!VoucherType = VoucherType
            dr!VoucherCode = VoucherCode
            dr!VoucherDate = VoucherDate
            dr!VoucherDescriotion = VoucherDescriotion
            dr!VoucherDebit = Convert.ToDecimal(VoucherDebit)
            dr!VoucherCredit = Convert.ToDecimal(VoucherCredit)
            dt.Rows.Add(dr)
            Dim cmd_Builder1 As New SqlClient.SqlCommandBuilder(adp)
            adp.Update(dt)
            SetSupplierTrans = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "فشل فى عملية الحفظ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly)

            'SetSupplierTrans = False
        End Try
    End Function

    Public Function CustomerTrans(CustomerName, VoucherType, VoucherCode, VoucherDate, VoucherDescriotion, VoucherDebit, VoucherCredit) As Boolean
        CustomerTrans = False
        Try
            Dim adp = New SqlClient.SqlDataAdapter("select * from CustomerTrans", SQLconn)
            Dim ds = New DataSet
            adp.Fill(ds)
            Dim dt = ds.Tables(0)
            Dim dr = dt.NewRow
            dr!CustomerName = CustomerName
            dr!VoucherType = VoucherType
            dr!VoucherCode = VoucherCode
            dr!VoucherDate = VoucherDate
            dr!VoucherDescriotion = VoucherDescriotion
            dr!VoucherDebit = Convert.ToDecimal(VoucherDebit)
            dr!VoucherCredit = Convert.ToDecimal(VoucherCredit)
            dt.Rows.Add(dr)
            Dim cmd_Builder1 As New SqlClient.SqlCommandBuilder(adp)
            adp.Update(dt)
            CustomerTrans = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "فشل فى عملية الحفظ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly)

            'SetSupplierTrans = False
        End Try
    End Function

    Public Sub GetItemUnits(Dgv As DataGridView, ItemCode As String)
        Dim Adp = New SqlClient.SqlDataAdapter("select * from Items where itemCode=N'" & ItemCode & "'", SQLconn)
        Dim DS = New DataSet
        Adp.Fill(DS)
        Dim dt = DS.Tables(0)
        If dt.Rows.Count > 0 Then
            Dim DGVCC As DataGridViewComboBoxCell
            DGVCC = Dgv.Rows(Dgv.Rows.Count - 1).Cells(2)
            DGVCC.Items.Add(dt.Rows(0).Item("FirstUnit"))
            If dt.Rows(0).Item("SecoundtUnit").ToString <> "" Then DGVCC.Items.Add(dt.Rows(0).Item("SecoundtUnit"))
            If dt.Rows(0).Item("ThirdUnit").ToString <> "" Then DGVCC.Items.Add(dt.Rows(0).Item("ThirdUnit"))
            Dgv.ClearSelection()
            Dgv.Rows(Dgv.Rows.Count - 1).Cells(2).Selected = True

        End If
    End Sub

    Sub FillList(ListBox As ListBox, TabelName As String, DisplayValue As String, status As Boolean)

        ListBox.Items.Clear()
        Dim Sql = ""

        If status = True Then
            Sql = "select * from " & TabelName & " where status='True' order by " & DisplayValue
        Else
            Sql = "select * from " & TabelName & " where status=False order by " & DisplayValue
        End If
        Dim Adp As New SqlClient.SqlDataAdapter(Sql, SQLconn)
        Dim DS As New DataSet
        Adp.Fill(DS)
        Dim dt = DS.Tables(0)

        '--------------------------======================
        For I = 0 To dt.Rows.Count - 1
            ListBox.Items.Add(dt.Rows(I).Item(DisplayValue))

        Next
    End Sub

    Sub FillComboList(CmBox As ComboBox, TabelName As String, DisplayValue As String, status As Boolean)

        CmBox.Items.Clear()
        Dim Sql = ""

        If status = True Then
            Sql = "select * from " & TabelName & " where status='True' order by " & DisplayValue
        Else
            Sql = "select * from " & TabelName & " where status=False order by " & DisplayValue
        End If
        Dim Adp As New SqlClient.SqlDataAdapter(Sql, SQLconn)
        Dim DS As New DataSet
        Adp.Fill(DS)
        Dim dt = DS.Tables(0)

        '--------------------------======================
        For I = 0 To dt.Rows.Count - 1
            CmBox.Items.Add(dt.Rows(I).Item(DisplayValue))

        Next
    End Sub
    Function GetDEf_Unit_Price(itemcode) As String
        GetDEf_Unit_Price = ""
        Dim UnitLevel As Integer = 0
        '____________________________________ جلب الوحدة الافتراضية للاصناف

        Dim Adp As New SqlClient.SqlDataAdapter("select * from Items where itemCode=N'" & itemcode & "'", SQLconn)
        Dim DS As New DataSet
        Adp.Fill(DS)
        Dim dt = DS.Tables(0)
        If dt.Rows.Count > 0 Then
            UnitLevel = dt.Rows(0).Item("UnitDefault")

            Select Case dt.Rows(0).Item("UnitDefault")
                Case 1
                    GetDEf_Unit_Price = dt.Rows(0).Item("FirstUnit")

                Case 2
                    GetDEf_Unit_Price = dt.Rows(0).Item("SecoundtUnit")

                Case 3
                    GetDEf_Unit_Price = dt.Rows(0).Item("ThirdUnit")


            End Select


            Adp.Dispose()
            DS.Dispose()
            dt.Dispose()

            '======================= جلب السعر الافتراضى للاصناف


            Adp = New SqlClient.SqlDataAdapter("select * from ItemNormalPricess where itemCode=N'" & itemcode & "'", SQLconn)
            DS = New DataSet
            Adp.Fill(DS)
            dt = DS.Tables(0)
            If dt.Rows.Count > 0 Then
                Select Case UnitLevel


                    Case 1
                        If dt.Rows(0).Item("PriceDefault") = 1 Then GetDEf_Unit_Price = GetDEf_Unit_Price & "|" & dt.Rows(0).Item("WholeSaleForFirstUnit")
                        If dt.Rows(0).Item("PriceDefault") = 2 Then GetDEf_Unit_Price = GetDEf_Unit_Price & "|" & dt.Rows(0).Item("HalfWholeSaleForFirstUnit")
                        If dt.Rows(0).Item("PriceDefault") = 3 Then GetDEf_Unit_Price = GetDEf_Unit_Price & "|" & dt.Rows(0).Item("DistributorForFirstUnit")
                        If dt.Rows(0).Item("PriceDefault") = 4 Then GetDEf_Unit_Price = GetDEf_Unit_Price & "|" & dt.Rows(0).Item("ExportForFirstUnit")
                        If dt.Rows(0).Item("PriceDefault") = 5 Then GetDEf_Unit_Price = GetDEf_Unit_Price & "|" & dt.Rows(0).Item("RetailForFirstUnit")
                        If dt.Rows(0).Item("PriceDefault") = 6 Then GetDEf_Unit_Price = GetDEf_Unit_Price & "|" & dt.Rows(0).Item("EndUserForFirstUnit")


                    Case 2
                        If dt.Rows(0).Item("PriceDefault") = 1 Then GetDEf_Unit_Price = GetDEf_Unit_Price & "|" & dt.Rows(0).Item("WholeSaleForSecondUnit")
                        If dt.Rows(0).Item("PriceDefault") = 2 Then GetDEf_Unit_Price = GetDEf_Unit_Price & "|" & dt.Rows(0).Item("HalfWholeSaleForSecondUnit")
                        If dt.Rows(0).Item("PriceDefault") = 3 Then GetDEf_Unit_Price = GetDEf_Unit_Price & "|" & dt.Rows(0).Item("DistributorForSecondUnit")
                        If dt.Rows(0).Item("PriceDefault") = 4 Then GetDEf_Unit_Price = GetDEf_Unit_Price & "|" & dt.Rows(0).Item("ExportForSecondUnit")
                        If dt.Rows(0).Item("PriceDefault") = 5 Then GetDEf_Unit_Price = GetDEf_Unit_Price & "|" & dt.Rows(0).Item("RetailForSecondUnit")
                        If dt.Rows(0).Item("PriceDefault") = 6 Then GetDEf_Unit_Price = GetDEf_Unit_Price & "|" & dt.Rows(0).Item("EndUserForSecondUnit")


                    Case 3
                        If dt.Rows(0).Item("PriceDefault") = 1 Then GetDEf_Unit_Price = GetDEf_Unit_Price & "|" & dt.Rows(0).Item("WholeSaleForThirdUnit")
                        If dt.Rows(0).Item("PriceDefault") = 2 Then GetDEf_Unit_Price = GetDEf_Unit_Price & "|" & dt.Rows(0).Item("HalfWholeSaleForThirdUnit")
                        If dt.Rows(0).Item("PriceDefault") = 3 Then GetDEf_Unit_Price = GetDEf_Unit_Price & "|" & dt.Rows(0).Item("DistributorForThirdUnit")
                        If dt.Rows(0).Item("PriceDefault") = 4 Then GetDEf_Unit_Price = GetDEf_Unit_Price & "|" & dt.Rows(0).Item("ExportForThirdUnit")
                        If dt.Rows(0).Item("PriceDefault") = 5 Then GetDEf_Unit_Price = GetDEf_Unit_Price & "|" & dt.Rows(0).Item("RetailForThirdUnit")
                        If dt.Rows(0).Item("PriceDefault") = 6 Then GetDEf_Unit_Price = GetDEf_Unit_Price & "|" & dt.Rows(0).Item("EndUserForThirdUnit")

                End Select
            End If

            GetDEf_Unit_Price = GetDEf_Unit_Price & "|" & UnitLevel

        End If
    End Function

    Public Function FillUnitPrice(PriceUnitGrid As DataGridView, CurrentItemCodeGrid As String, UnitLevel As String)
        FillUnitPrice = ""
        PriceUnitGrid.Rows.Clear()

        Dim arrunit(5) As String
        arrunit(0) = "سعر الجملة :" : arrunit(1) = "سعر نصف الجملة :" : arrunit(2) = "سعر الموزع :"
        arrunit(3) = "سعر التصدير :" : arrunit(4) = "سعر بيع التجزئة :" : arrunit(5) = "سعر المستهلك :"
        For i = 0 To 5
            PriceUnitGrid.Rows.Add()
            PriceUnitGrid.Rows(i).Cells(1).Value = arrunit(i)
        Next

        If CurrentItemCodeGrid = String.Empty Then Exit Function

        Dim STR = "select * from ItemNormalPricess where ItemCode=N'" & CurrentItemCodeGrid & "' "
        Dim Adp = New SqlClient.SqlDataAdapter(STR, SQLconn)
        Dim DS = New DataSet
        Adp.Fill(DS)
        Dim DT = DS.Tables(0)

        If DT.Rows.Count = 0 Then Exit Function

        Dim dr = DT.Rows(0)
        Dim arrPrice(5) As String
        Select Case UnitLevel
            Case 1
                arrPrice(0) = dr!WholeSaleForFirstUnit
                arrPrice(1) = dr!HalfWholeSaleForFirstUnit
                arrPrice(2) = dr!DistributorForFirstUnit
                arrPrice(3) = dr!ExportForFirstUnit
                arrPrice(4) = dr!RetailForFirstUnit
                arrPrice(5) = dr!EndUserForFirstUnit
            Case 2
                arrPrice(0) = dr!WholeSaleForSecondUnit
                arrPrice(1) = dr!HalfWholeSaleForSecondUnit
                arrPrice(2) = dr!DistributorForSecondUnit
                arrPrice(3) = dr!ExportForSecondUnit
                arrPrice(4) = dr!RetailForSecondUnit
                arrPrice(5) = dr!EndUserForSecondUnit
            Case 3
                arrPrice(0) = dr!WholeSaleForThirdUnit
                arrPrice(1) = dr!HalfWholeSaleForThirdUnit
                arrPrice(2) = dr!DistributorForThirdUnit
                arrPrice(3) = dr!ExportForThirdUnit
                arrPrice(4) = dr!RetailForThirdUnit
                arrPrice(5) = dr!EndUserForThirdUnit

        End Select

        For i = 0 To 5
            If Val(arrPrice(i)) > 0 Then
                PriceUnitGrid.Rows(i).Cells(2).Value = Format(Val(arrPrice(i)), "0.000")
            End If
        Next


    End Function
    Function GetUnitBarcode(itemcode, unitlevel) As String
        GetUnitBarcode = 0
        Dim Adp = New SqlClient.SqlDataAdapter("select * from Items where itemCode=N'" & itemcode & "'", SQLconn)
        Dim DS = New DataSet
        Adp.Fill(DS)
        Dim dt = DS.Tables(0)
        If dt.Rows.Count > 0 Then
            If unitlevel = 1 Then GetUnitBarcode = dt.Rows(0).Item("FirstUnitBarcode")
            If unitlevel = 2 Then GetUnitBarcode = dt.Rows(0).Item("SecoundtUnitBarcode")
            If unitlevel = 3 Then GetUnitBarcode = dt.Rows(0).Item("ThirdtUnitBarcode")
        End If
    End Function


End Module
