// File:    Doctor.cs
// Author:  Geri
// Created: 18. april 2020 19:45:12
// Purpose: Definition of Class Doctor

using System;
using Model.Doctor;

namespace Model.User
{
   public class Doctor : Employee
   {
      public Room office;
      public System.Collections.Generic.List<DocTypeEnum> docTypeEnum;
      
      /// <summary>
      /// Property for collection of DocTypeEnum
      /// </summary>
      /// <pdGenerated>Default opposite class collection property</pdGenerated>
      public System.Collections.Generic.List<DocTypeEnum> DocTypeEnum
      {
         get
         {
            if (docTypeEnum == null)
               docTypeEnum = new System.Collections.Generic.List<DocTypeEnum>();
            return docTypeEnum;
         }
         set
         {
            RemoveAllDocTypeEnum();
            if (value != null)
            {
               foreach (DocTypeEnum oDocTypeEnum in value)
                  AddDocTypeEnum(oDocTypeEnum);
            }
         }
      }
      
      /// <summary>
      /// Add a new DocTypeEnum in the collection
      /// </summary>
      /// <pdGenerated>Default Add</pdGenerated>
      public void AddDocTypeEnum(DocTypeEnum newDocTypeEnum)
      {
         if (newDocTypeEnum == null)
            return;
         if (this.docTypeEnum == null)
            this.docTypeEnum = new System.Collections.Generic.List<DocTypeEnum>();
         if (!this.docTypeEnum.Contains(newDocTypeEnum))
            this.docTypeEnum.Add(newDocTypeEnum);
      }
      
      /// <summary>
      /// Remove an existing DocTypeEnum from the collection
      /// </summary>
      /// <pdGenerated>Default Remove</pdGenerated>
      public void RemoveDocTypeEnum(DocTypeEnum oldDocTypeEnum)
      {
         if (oldDocTypeEnum == null)
            return;
         if (this.docTypeEnum != null)
            if (this.docTypeEnum.Contains(oldDocTypeEnum))
               this.docTypeEnum.Remove(oldDocTypeEnum);
      }
      
      /// <summary>
      /// Remove all instances of DocTypeEnum from the collection
      /// </summary>
      /// <pdGenerated>Default removeAll</pdGenerated>
      public void RemoveAllDocTypeEnum()
      {
         if (docTypeEnum != null)
            docTypeEnum.Clear();
      }
   
   }
}