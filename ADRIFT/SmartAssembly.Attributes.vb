' Licence: Everyone is free to use the code contained in this file in any way.
Namespace SmartAssembly.Attributes

    <AttributeUsage(AttributeTargets.Class Or AttributeTargets.Method Or AttributeTargets.Constructor Or AttributeTargets.Struct)> _
    Public NotInheritable Class DoNotCaptureVariablesAttribute
        Inherits Attribute

    End Class

    <DoNotObfuscate>
    <SmartAssembly.Attributes.DoNotPrune>
    <AttributeUsage(AttributeTargets.Field Or AttributeTargets.Class Or AttributeTargets.Struct, Inherited:=True)> _
    Public NotInheritable Class DoNotCaptureAttribute
        Inherits Attribute

    End Class

    <AttributeUsage(AttributeTargets.Assembly Or AttributeTargets.Class Or AttributeTargets.Delegate Or AttributeTargets.Enum Or AttributeTargets.Field Or AttributeTargets.Interface Or AttributeTargets.Method Or AttributeTargets.Module Or AttributeTargets.Struct)> _
    Public NotInheritable Class DoNotObfuscateAttribute
        Inherits Attribute

    End Class

    <AttributeUsage(AttributeTargets.Class Or AttributeTargets.Enum Or AttributeTargets.Interface Or AttributeTargets.Struct)> _
    Public NotInheritable Class DoNotObfuscateTypeAttribute
        Inherits Attribute

    End Class

    <AttributeUsage(AttributeTargets.Assembly Or AttributeTargets.Class Or AttributeTargets.Constructor Or AttributeTargets.Delegate Or AttributeTargets.Enum Or AttributeTargets.Event Or AttributeTargets.Field Or AttributeTargets.Interface Or AttributeTargets.Method Or AttributeTargets.Module Or AttributeTargets.Parameter Or AttributeTargets.Property Or AttributeTargets.Struct)> _
    Public NotInheritable Class DoNotPruneAttribute
        Inherits Attribute

    End Class

    <AttributeUsage(AttributeTargets.Class Or AttributeTargets.Enum Or AttributeTargets.Interface Or AttributeTargets.Struct)> _
    Public NotInheritable Class DoNotPruneTypeAttribute
        Inherits Attribute

    End Class

    <AttributeUsage(AttributeTargets.Class)> _
    Public NotInheritable Class DoNotSealTypeAttribute
        Inherits Attribute

    End Class

    <AttributeUsage(AttributeTargets.Method)> _
    Public NotInheritable Class ReportExceptionAttribute
        Inherits Attribute

    End Class

    <AttributeUsage(AttributeTargets.Method Or AttributeTargets.Constructor)> _
    Public NotInheritable Class ReportUsageAttribute
        Inherits Attribute

        Public Sub New()
        End Sub

        Public Sub New(ByVal newName As String)
        End Sub
    End Class

    <AttributeUsage(AttributeTargets.Class Or AttributeTargets.Method Or AttributeTargets.Constructor Or AttributeTargets.Struct)> _
    Public NotInheritable Class ObfuscateControlFlowAttribute
        Inherits Attribute

    End Class

    <AttributeUsage(AttributeTargets.Class Or AttributeTargets.Method Or AttributeTargets.Constructor Or AttributeTargets.Struct)> _
    Public NotInheritable Class DoNotObfuscateControlFlowAttribute
        Inherits Attribute

    End Class

    <AttributeUsage(AttributeTargets.Class Or AttributeTargets.Enum Or AttributeTargets.Field Or AttributeTargets.Interface Or AttributeTargets.Method Or AttributeTargets.Struct)> _
    Public NotInheritable Class ObfuscateToAttribute
        Inherits Attribute

        Public Sub New(ByVal newName As String)
        End Sub
    End Class

    <AttributeUsage(AttributeTargets.Class Or AttributeTargets.Enum Or AttributeTargets.Interface Or AttributeTargets.Struct)> _
    Public NotInheritable Class ObfuscateNamespaceToAttribute
        Inherits Attribute

        Public Sub New(ByVal newName As String)
        End Sub
    End Class

    <AttributeUsage(AttributeTargets.Assembly Or AttributeTargets.Class Or AttributeTargets.Method Or AttributeTargets.Constructor Or AttributeTargets.Module Or AttributeTargets.Struct)> _
    Public NotInheritable Class DoNotEncodeStringsAttribute
        Inherits Attribute

    End Class

    <AttributeUsage(AttributeTargets.Class Or AttributeTargets.Method Or AttributeTargets.Constructor Or AttributeTargets.Struct)> _
    Public NotInheritable Class EncodeStringsAttribute
        Inherits Attribute

    End Class

    <AttributeUsage(AttributeTargets.Assembly Or AttributeTargets.Class Or AttributeTargets.Constructor Or AttributeTargets.Method Or AttributeTargets.Module Or AttributeTargets.Struct)> _
    Public NotInheritable Class ExcludeFromMemberRefsProxyAttribute
        Inherits Attribute

    End Class

    <AttributeUsage(AttributeTargets.Class Or AttributeTargets.Struct Or AttributeTargets.Interface Or AttributeTargets.Enum Or AttributeTargets.Delegate)>
    Public NotInheritable Class StayPublicAttribute
        Inherits Attribute

    End Class

    <AttributeUsage(AttributeTargets.Method)>
    Public NotInheritable Class DoNotMoveAttribute
        Inherits Attribute

    End Class

    <AttributeUsage(AttributeTargets.Class)>
    Public NotInheritable Class DoNotMoveMethodsAttribute
        Inherits Attribute

    End Class

End Namespace