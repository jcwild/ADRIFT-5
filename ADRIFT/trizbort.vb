﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:4.0.30319.235
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

' xsd trizbort.xsd /classes /language:vb

Option Strict On
Option Explicit On

Imports System.Xml.Serialization

'
'This source code was auto-generated by xsd, Version=4.0.30319.1.
'

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),  _
 System.SerializableAttribute(),  _
 System.Diagnostics.DebuggerStepThroughAttribute(),  _
 System.ComponentModel.DesignerCategoryAttribute("code"),  _
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=true),  _
 System.Xml.Serialization.XmlRootAttribute([Namespace]:="", IsNullable:=false)>  _
Partial Public Class trizbort
    
    Private infoField As trizbortInfo
    
    Private mapField() As Object
    
    Private settingsField As trizbortSettings
    
    '''<remarks/>
    Public Property info() As trizbortInfo
        Get
            Return Me.infoField
        End Get
        Set
            Me.infoField = value
        End Set
    End Property
    
    '''<remarks/>
    <System.Xml.Serialization.XmlArrayItemAttribute("line", GetType(trizbortLine), IsNullable:=false),  _
     System.Xml.Serialization.XmlArrayItemAttribute("room", GetType(trizbortRoom), IsNullable:=false)>  _
    Public Property map() As Object()
        Get
            Return Me.mapField
        End Get
        Set
            Me.mapField = value
        End Set
    End Property
    
    '''<remarks/>
    Public Property settings() As trizbortSettings
        Get
            Return Me.settingsField
        End Get
        Set
            Me.settingsField = value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),  _
 System.SerializableAttribute(),  _
 System.Diagnostics.DebuggerStepThroughAttribute(),  _
 System.ComponentModel.DesignerCategoryAttribute("code"),  _
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=true)>  _
Partial Public Class trizbortInfo
    
    Private titleField As String
    
    Private authorField As String
    
    Private descriptionField As String
    
    '''<remarks/>
    Public Property title() As String
        Get
            Return Me.titleField
        End Get
        Set
            Me.titleField = value
        End Set
    End Property
    
    '''<remarks/>
    Public Property author() As String
        Get
            Return Me.authorField
        End Get
        Set
            Me.authorField = value
        End Set
    End Property
    
    '''<remarks/>
    Public Property description() As String
        Get
            Return Me.descriptionField
        End Get
        Set
            Me.descriptionField = value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),  _
 System.SerializableAttribute(),  _
 System.Diagnostics.DebuggerStepThroughAttribute(),  _
 System.ComponentModel.DesignerCategoryAttribute("code"),  _
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=true)>  _
Partial Public Class trizbortLine
    
    Private dockField() As trizbortLineDock
    
    Private textField() As String
    
    Private idField As Integer

    Private idFieldSpecified As Boolean

    Private styleField As String

    Private flowField As String

    Private startTextField As String

    Private endTextField As String

    Private nameField As String

    Private xField As Integer

    Private xFieldSpecified As Boolean

    Private yField As Integer

    Private yFieldSpecified As Boolean

    Private wField As Integer

    Private wFieldSpecified As Boolean

    Private hField As Integer

    Private hFieldSpecified As Boolean

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute("dock")> _
    Public Property dock() As trizbortLineDock()
        Get
            Return Me.dockField
        End Get
        Set(value As trizbortLineDock())
            Me.dockField = value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlTextAttribute()> _
    Public Property Text() As String()
        Get
            Return Me.textField
        End Get
        Set(value As String())
            Me.textField = value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()> _
    Public Property id() As Integer
        Get
            Return Me.idField
        End Get
        Set(value As Integer)
            Me.idField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlIgnoreAttribute()> _
    Public Property idSpecified() As Boolean
        Get
            Return Me.idFieldSpecified
        End Get
        Set(value As Boolean)
            Me.idFieldSpecified = value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()> _
    Public Property style() As String
        Get
            Return Me.styleField
        End Get
        Set(value As String)
            Me.styleField = value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()> _
    Public Property flow() As String
        Get
            Return Me.flowField
        End Get
        Set(value As String)
            Me.flowField = value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()> _
    Public Property startText() As String
        Get
            Return Me.startTextField
        End Get
        Set(value As String)
            Me.startTextField = value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()> _
    Public Property endText() As String
        Get
            Return Me.endTextField
        End Get
        Set(value As String)
            Me.endTextField = value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()> _
    Public Property name() As String
        Get
            Return Me.nameField
        End Get
        Set(value As String)
            Me.nameField = value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()> _
    Public Property x() As Integer
        Get
            Return Me.xField
        End Get
        Set(value As Integer)
            Me.xField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlIgnoreAttribute()> _
    Public Property xSpecified() As Boolean
        Get
            Return Me.xFieldSpecified
        End Get
        Set(value As Boolean)
            Me.xFieldSpecified = value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()> _
    Public Property y() As Integer
        Get
            Return Me.yField
        End Get
        Set(value As Integer)
            Me.yField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlIgnoreAttribute()> _
    Public Property ySpecified() As Boolean
        Get
            Return Me.yFieldSpecified
        End Get
        Set(value As Boolean)
            Me.yFieldSpecified = value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()> _
    Public Property w() As Integer
        Get
            Return Me.wField
        End Get
        Set(value As Integer)
            Me.wField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlIgnoreAttribute()> _
    Public Property wSpecified() As Boolean
        Get
            Return Me.wFieldSpecified
        End Get
        Set(value As Boolean)
            Me.wFieldSpecified = value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()> _
    Public Property h() As Integer
        Get
            Return Me.hField
        End Get
        Set(value As Integer)
            Me.hField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlIgnoreAttribute()> _
    Public Property hSpecified() As Boolean
        Get
            Return Me.hFieldSpecified
        End Get
        Set(value As Boolean)
            Me.hFieldSpecified = value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"), _
 System.SerializableAttribute(), _
 System.Diagnostics.DebuggerStepThroughAttribute(), _
 System.ComponentModel.DesignerCategoryAttribute("code"), _
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)> _
Partial Public Class trizbortLineDock

    Private indexField As Integer

    Private indexFieldSpecified As Boolean

    Private idField As Integer

    Private idFieldSpecified As Boolean

    Private portField As String

    Private valueField As String

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()> _
    Public Property index() As Integer
        Get
            Return Me.indexField
        End Get
        Set(value As Integer)
            Me.indexField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlIgnoreAttribute()> _
    Public Property indexSpecified() As Boolean
        Get
            Return Me.indexFieldSpecified
        End Get
        Set(value As Boolean)
            Me.indexFieldSpecified = value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()> _
    Public Property id() As Integer
        Get
            Return Me.idField
        End Get
        Set(value As Integer)
            Me.idField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlIgnoreAttribute()> _
    Public Property idSpecified() As Boolean
        Get
            Return Me.idFieldSpecified
        End Get
        Set(value As Boolean)
            Me.idFieldSpecified = value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()> _
    Public Property port() As String
        Get
            Return Me.portField
        End Get
        Set(value As String)
            Me.portField = value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlTextAttribute()> _
    Public Property Value() As String
        Get
            Return Me.valueField
        End Get
        Set(value As String)
            Me.valueField = value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"), _
 System.SerializableAttribute(), _
 System.Diagnostics.DebuggerStepThroughAttribute(), _
 System.ComponentModel.DesignerCategoryAttribute("code"), _
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)> _
Partial Public Class trizbortRoom

    Private objectsField As String

    Private idField As Integer

    Private idFieldSpecified As Boolean

    Private nameField As String

    Private xField As Integer

    Private xFieldSpecified As Boolean

    Private yField As Integer

    Private yFieldSpecified As Boolean

    Private wField As Integer

    Private wFieldSpecified As Boolean

    Private hField As Integer

    Private hFieldSpecified As Boolean

    Private descriptionField As String

    '''<remarks/>
    Public Property objects() As String
        Get
            Return Me.objectsField
        End Get
        Set(value As String)
            Me.objectsField = value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()> _
    Public Property id() As Integer
        Get
            Return Me.idField
        End Get
        Set(value As Integer)
            Me.idField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlIgnoreAttribute()> _
    Public Property idSpecified() As Boolean
        Get
            Return Me.idFieldSpecified
        End Get
        Set(value As Boolean)
            Me.idFieldSpecified = value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()> _
    Public Property name() As String
        Get
            Return Me.nameField
        End Get
        Set(value As String)
            Me.nameField = value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()> _
    Public Property x() As Integer
        Get
            Return Me.xField
        End Get
        Set(value As Integer)
            Me.xField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlIgnoreAttribute()> _
    Public Property xSpecified() As Boolean
        Get
            Return Me.xFieldSpecified
        End Get
        Set(value As Boolean)
            Me.xFieldSpecified = value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()> _
    Public Property y() As Integer
        Get
            Return Me.yField
        End Get
        Set(value As Integer)
            Me.yField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlIgnoreAttribute()> _
    Public Property ySpecified() As Boolean
        Get
            Return Me.yFieldSpecified
        End Get
        Set(value As Boolean)
            Me.yFieldSpecified = value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()> _
    Public Property w() As Integer
        Get
            Return Me.wField
        End Get
        Set(value As Integer)
            Me.wField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlIgnoreAttribute()> _
    Public Property wSpecified() As Boolean
        Get
            Return Me.wFieldSpecified
        End Get
        Set(value As Boolean)
            Me.wFieldSpecified = value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()> _
    Public Property h() As Integer
        Get
            Return Me.hField
        End Get
        Set(value As Integer)
            Me.hField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlIgnoreAttribute()> _
    Public Property hSpecified() As Boolean
        Get
            Return Me.hFieldSpecified
        End Get
        Set(value As Boolean)
            Me.hFieldSpecified = value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()> _
    Public Property description() As String
        Get
            Return Me.descriptionField
        End Get
        Set(value As String)
            Me.descriptionField = value
        End Set
    End Property

End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"), _
 System.SerializableAttribute(), _
 System.Diagnostics.DebuggerStepThroughAttribute(), _
 System.ComponentModel.DesignerCategoryAttribute("code"), _
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)> _
Partial Public Class trizbortSettings

    Private colorsField As trizbortSettingsColors

    Private fontsField As trizbortSettingsFonts

    Private gridField As trizbortSettingsGrid

    Private linesField As trizbortSettingsLines

    Private roomsField As trizbortSettingsRooms

    Private uiField As trizbortSettingsUI

    '''<remarks/>
    Public Property colors() As trizbortSettingsColors
        Get
            Return Me.colorsField
        End Get
        Set(value As trizbortSettingsColors)
            Me.colorsField = value
        End Set
    End Property

    '''<remarks/>
    Public Property fonts() As trizbortSettingsFonts
        Get
            Return Me.fontsField
        End Get
        Set(value As trizbortSettingsFonts)
            Me.fontsField = value
        End Set
    End Property

    '''<remarks/>
    Public Property grid() As trizbortSettingsGrid
        Get
            Return Me.gridField
        End Get
        Set(value As trizbortSettingsGrid)
            Me.gridField = value
        End Set
    End Property

    '''<remarks/>
    Public Property lines() As trizbortSettingsLines
        Get
            Return Me.linesField
        End Get
        Set(value As trizbortSettingsLines)
            Me.linesField = value
        End Set
    End Property

    '''<remarks/>
    Public Property rooms() As trizbortSettingsRooms
        Get
            Return Me.roomsField
        End Get
        Set(value As trizbortSettingsRooms)
            Me.roomsField = value
        End Set
    End Property

    '''<remarks/>
    Public Property ui() As trizbortSettingsUI
        Get
            Return Me.uiField
        End Get
        Set(value As trizbortSettingsUI)
            Me.uiField = value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"), _
 System.SerializableAttribute(), _
 System.Diagnostics.DebuggerStepThroughAttribute(), _
 System.ComponentModel.DesignerCategoryAttribute("code"), _
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)> _
Partial Public Class trizbortSettingsColors

    Private canvasField As String

    Private fillField As String

    Private borderField As String

    Private lineField As String

    Private selectedLineField As String

    Private hoverLineField As String

    Private largeTextField As String

    Private smallTextField As String

    Private lineTextField As String

    Private gridField As String

    '''<remarks/>
    Public Property canvas() As String
        Get
            Return Me.canvasField
        End Get
        Set(value As String)
            Me.canvasField = value
        End Set
    End Property

    '''<remarks/>
    Public Property fill() As String
        Get
            Return Me.fillField
        End Get
        Set(value As String)
            Me.fillField = value
        End Set
    End Property

    '''<remarks/>
    Public Property border() As String
        Get
            Return Me.borderField
        End Get
        Set(value As String)
            Me.borderField = value
        End Set
    End Property

    '''<remarks/>
    Public Property line() As String
        Get
            Return Me.lineField
        End Get
        Set(value As String)
            Me.lineField = value
        End Set
    End Property

    '''<remarks/>
    Public Property selectedLine() As String
        Get
            Return Me.selectedLineField
        End Get
        Set(value As String)
            Me.selectedLineField = value
        End Set
    End Property

    '''<remarks/>
    Public Property hoverLine() As String
        Get
            Return Me.hoverLineField
        End Get
        Set(value As String)
            Me.hoverLineField = value
        End Set
    End Property

    '''<remarks/>
    Public Property largeText() As String
        Get
            Return Me.largeTextField
        End Get
        Set(value As String)
            Me.largeTextField = value
        End Set
    End Property

    '''<remarks/>
    Public Property smallText() As String
        Get
            Return Me.smallTextField
        End Get
        Set(value As String)
            Me.smallTextField = value
        End Set
    End Property

    '''<remarks/>
    Public Property lineText() As String
        Get
            Return Me.lineTextField
        End Get
        Set(value As String)
            Me.lineTextField = value
        End Set
    End Property

    '''<remarks/>
    Public Property grid() As String
        Get
            Return Me.gridField
        End Get
        Set(value As String)
            Me.gridField = value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"), _
 System.SerializableAttribute(), _
 System.Diagnostics.DebuggerStepThroughAttribute(), _
 System.ComponentModel.DesignerCategoryAttribute("code"), _
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)> _
Partial Public Class trizbortSettingsFonts

    Private roomField As trizbortSettingsFontsRoom

    Private objectField As trizbortSettingsFontsObject

    Private lineField As trizbortSettingsFontsLine

    '''<remarks/>
    Public Property room() As trizbortSettingsFontsRoom
        Get
            Return Me.roomField
        End Get
        Set(value As trizbortSettingsFontsRoom)
            Me.roomField = value
        End Set
    End Property

    '''<remarks/>
    Public Property [object]() As trizbortSettingsFontsObject
        Get
            Return Me.objectField
        End Get
        Set(value As trizbortSettingsFontsObject)
            Me.objectField = value
        End Set
    End Property

    '''<remarks/>
    Public Property line() As trizbortSettingsFontsLine
        Get
            Return Me.lineField
        End Get
        Set(value As trizbortSettingsFontsLine)
            Me.lineField = value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"), _
 System.SerializableAttribute(), _
 System.Diagnostics.DebuggerStepThroughAttribute(), _
 System.ComponentModel.DesignerCategoryAttribute("code"), _
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)> _
Partial Public Class trizbortSettingsFontsRoom

    Private sizeField As Integer

    Private sizeFieldSpecified As Boolean

    Private valueField As String

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()> _
    Public Property size() As Integer
        Get
            Return Me.sizeField
        End Get
        Set(value As Integer)
            Me.sizeField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlIgnoreAttribute()> _
    Public Property sizeSpecified() As Boolean
        Get
            Return Me.sizeFieldSpecified
        End Get
        Set(value As Boolean)
            Me.sizeFieldSpecified = value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlTextAttribute()> _
    Public Property Value() As String
        Get
            Return Me.valueField
        End Get
        Set(value As String)
            Me.valueField = value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"), _
 System.SerializableAttribute(), _
 System.Diagnostics.DebuggerStepThroughAttribute(), _
 System.ComponentModel.DesignerCategoryAttribute("code"), _
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)> _
Partial Public Class trizbortSettingsFontsObject

    Private sizeField As Integer

    Private sizeFieldSpecified As Boolean

    Private valueField As String

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()> _
    Public Property size() As Integer
        Get
            Return Me.sizeField
        End Get
        Set(value As Integer)
            Me.sizeField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlIgnoreAttribute()> _
    Public Property sizeSpecified() As Boolean
        Get
            Return Me.sizeFieldSpecified
        End Get
        Set(value As Boolean)
            Me.sizeFieldSpecified = value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlTextAttribute()> _
    Public Property Value() As String
        Get
            Return Me.valueField
        End Get
        Set(value As String)
            Me.valueField = value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"), _
 System.SerializableAttribute(), _
 System.Diagnostics.DebuggerStepThroughAttribute(), _
 System.ComponentModel.DesignerCategoryAttribute("code"), _
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)> _
Partial Public Class trizbortSettingsFontsLine

    Private sizeField As Integer

    Private sizeFieldSpecified As Boolean

    Private valueField As String

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()> _
    Public Property size() As Integer
        Get
            Return Me.sizeField
        End Get
        Set(value As Integer)
            Me.sizeField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlIgnoreAttribute()> _
    Public Property sizeSpecified() As Boolean
        Get
            Return Me.sizeFieldSpecified
        End Get
        Set(value As Boolean)
            Me.sizeFieldSpecified = value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlTextAttribute()> _
    Public Property Value() As String
        Get
            Return Me.valueField
        End Get
        Set(value As String)
            Me.valueField = value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"), _
 System.SerializableAttribute(), _
 System.Diagnostics.DebuggerStepThroughAttribute(), _
 System.ComponentModel.DesignerCategoryAttribute("code"), _
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)> _
Partial Public Class trizbortSettingsGrid

    Private snapToField As String

    Private visibleField As String

    Private showOriginField As String

    Private sizeField As Integer

    '''<remarks/>
    Public Property snapTo() As String
        Get
            Return Me.snapToField
        End Get
        Set(value As String)
            Me.snapToField = value
        End Set
    End Property

    '''<remarks/>
    Public Property visible() As String
        Get
            Return Me.visibleField
        End Get
        Set(value As String)
            Me.visibleField = value
        End Set
    End Property

    '''<remarks/>
    Public Property showOrigin() As String
        Get
            Return Me.showOriginField
        End Get
        Set(value As String)
            Me.showOriginField = value
        End Set
    End Property

    '''<remarks/>
    Public Property size() As Integer
        Get
            Return Me.sizeField
        End Get
        Set(value As Integer)
            Me.sizeField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"), _
 System.SerializableAttribute(), _
 System.Diagnostics.DebuggerStepThroughAttribute(), _
 System.ComponentModel.DesignerCategoryAttribute("code"), _
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)> _
Partial Public Class trizbortSettingsLines

    Private widthField As Integer

    Private handDrawnField As String

    Private arrowSizeField As Integer

    Private textOffsetField As Integer

    '''<remarks/>
    Public Property width() As Integer
        Get
            Return Me.widthField
        End Get
        Set(value As Integer)
            Me.widthField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property handDrawn() As String
        Get
            Return Me.handDrawnField
        End Get
        Set(value As String)
            Me.handDrawnField = value
        End Set
    End Property

    '''<remarks/>
    Public Property arrowSize() As Integer
        Get
            Return Me.arrowSizeField
        End Get
        Set(value As Integer)
            Me.arrowSizeField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property textOffset() As Integer
        Get
            Return Me.textOffsetField
        End Get
        Set(value As Integer)
            Me.textOffsetField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"), _
 System.SerializableAttribute(), _
 System.Diagnostics.DebuggerStepThroughAttribute(), _
 System.ComponentModel.DesignerCategoryAttribute("code"), _
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)> _
Partial Public Class trizbortSettingsRooms

    Private darknessStripeSizeField As Integer

    Private objectListOffsetField As Integer

    Private connectionStalkLengthField As Integer

    '''<remarks/>
    Public Property darknessStripeSize() As Integer
        Get
            Return Me.darknessStripeSizeField
        End Get
        Set(value As Integer)
            Me.darknessStripeSizeField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property objectListOffset() As Integer
        Get
            Return Me.objectListOffsetField
        End Get
        Set(value As Integer)
            Me.objectListOffsetField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property connectionStalkLength() As Integer
        Get
            Return Me.connectionStalkLengthField
        End Get
        Set(value As Integer)
            Me.connectionStalkLengthField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"), _
 System.SerializableAttribute(), _
 System.Diagnostics.DebuggerStepThroughAttribute(), _
 System.ComponentModel.DesignerCategoryAttribute("code"), _
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)> _
Partial Public Class trizbortSettingsUI

    Private handleSizeField As Integer

    Private snapToElementSizeField As Integer

    '''<remarks/>
    Public Property handleSize() As Integer
        Get
            Return Me.handleSizeField
        End Get
        Set(value As Integer)
            Me.handleSizeField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property snapToElementSize() As Integer
        Get
            Return Me.snapToElementSizeField
        End Get
        Set(value As Integer)
            Me.snapToElementSizeField = Value
        End Set
    End Property
End Class
