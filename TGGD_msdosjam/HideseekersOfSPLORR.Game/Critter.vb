Imports HideseekersOfSPLORR.Data

Public Class Critter
    ReadOnly Property Id As Long
    Sub New(critterId As Long)
        Id = critterId
    End Sub
    Function Attack(character As Character) As Boolean
        Dim item = character.Inventory.GetItemType(ItemType.Spear)
        If item IsNot Nothing Then
            If character.Characteristics.Check(Characteristic.Dexterity, TaskDifficulty.Difficult).IsSuccess Then
                Dim corpseItemId = ItemData.Create(ItemType.CritterCorpse)
                LocationItemData.Write(character.Location.Id, corpseItemId)
                CritterData.Destroy(Id)
                Return True
            End If
            item.Destroy()
        End If
        Return False
    End Function
    Public Overrides Function ToString() As String
        Dim critterType = CritterData.ReadCritterType(Id)
        If critterType IsNot Nothing Then
            Return CType(critterType.Value, CritterType).GetName
        Else
            Return ""
        End If
    End Function
End Class
