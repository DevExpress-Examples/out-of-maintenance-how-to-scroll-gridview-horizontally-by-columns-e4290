Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq

Namespace GridHorizontalScrolling
	Public Class Customers

		' Fields...
		Private _Nine As String
		Private _Eight As String
		Private _Seven As String
		Private _Six As String
		Private _Five As String
		Private _Four As String
		Private _Three As String
		Private _Two As String
		Private _One As String
		Private _Zero As String

		Public Property Zero() As String
			Get
				Return _Zero
			End Get
			Set(ByVal value As String)
				_Zero = value
			End Set
		End Property


		Public Property One() As String
			Get
				Return _One
			End Get
			Set(ByVal value As String)
				_One = value
			End Set
		End Property

		Public Property Two() As String
			Get
				Return _Two
			End Get
			Set(ByVal value As String)
				_Two = value
			End Set
		End Property

		Public Property Three() As String
			Get
				Return _Three
			End Get
			Set(ByVal value As String)
				_Three = value
			End Set
		End Property

		Public Property Four() As String
			Get
				Return _Four
			End Get
			Set(ByVal value As String)
				_Four = value
			End Set
		End Property

		Public Property Five() As String
			Get
				Return _Five
			End Get
			Set(ByVal value As String)
				_Five = value
			End Set
		End Property

		Public Property Six() As String
			Get
				Return _Six
			End Get
			Set(ByVal value As String)
				_Six = value
			End Set
		End Property

		Public Property Seven() As String
			Get
				Return _Seven
			End Get
			Set(ByVal value As String)
				_Seven = value
			End Set
		End Property

		Public Property Eight() As String
			Get
				Return _Eight
			End Get
			Set(ByVal value As String)
				_Eight = value
			End Set
		End Property

		Public Property Nine() As String
			Get
				Return _Nine
			End Get
			Set(ByVal value As String)
				_Nine = value
			End Set
		End Property
	End Class
End Namespace
