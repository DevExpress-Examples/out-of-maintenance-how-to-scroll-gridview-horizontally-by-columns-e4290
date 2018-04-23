Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms

Namespace GridHorizontalScrolling
	Partial Public Class Form1
		Inherits Form
		Private listOfCustomers As New BindingList(Of Customers)()
		Private Extension As GridEcxtensionHorizontalScrolling

		Public Sub New()
			InitializeComponent()
			gridControl1.DataSource = FillTables()
			gridView1.Columns(0).Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
			AddHandler gridView1.LeftCoordChanged, AddressOf gridView1_LeftCoordChanged
			Extension = New GridEcxtensionHorizontalScrolling(gridView1)
		End Sub

		Private Sub gridView1_LeftCoordChanged(ByVal sender As Object, ByVal e As EventArgs)
			textEdit1.Text = Extension.UpdateIndexInEditor().ToString()
		End Sub

		Private Function FillTables() As BindingList(Of Customers)
			listOfCustomers.Clear()
			For i As Integer = 0 To 4
				listOfCustomers.Add(New Customers())
			Next i
			Return listOfCustomers
		End Function

		Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
			Extension.UpdateFixedColumnsCount()
			textEdit1.Text = Extension.UpdateIndexInEditor().ToString()
		End Sub

		Private Sub simpleButton1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles simpleButton1.Click
			Extension.ScrollForward()
		End Sub

		Private Sub simpleButton2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles simpleButton2.Click
			Extension.ScrollBackward()
		End Sub

		Private Sub textEdit1_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles textEdit1.KeyDown
			If e.KeyCode = Keys.Enter Then
				If textEdit1.Text <> String.Empty Then
					Extension.ScrollTo(Convert.ToInt32(textEdit1.Text))
				End If
			End If
		End Sub
	End Class
End Namespace