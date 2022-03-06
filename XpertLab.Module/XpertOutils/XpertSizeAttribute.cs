using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XpertLab.Module.XpertOutils
{
    public sealed class XpertSizeAttribute : Attribute
    {
        public const int Unlimited = -1;
        //
        // Summary:
        //     Specifies the default size of the database column which the member’s data is
        //     stored in. The default value is 100.
        public const int DefaultStringMappingFieldSize = 100;
        public const int ItemName_Size = 150;
        public const int ItemID_Size = 50;
        public const int Adresse_Size = 500;
        public const int TypeDocumentSize = 50;
        public const int NumDocument = 30;
        public const int CodeDocument = 30;
        public const int SizeExerciceName = 10;
        public const int StatusExercice = 10;
        public const int MoisPeriodePaie = 2;
        public const int CodeDevise_Size = 3;
        public const int CodeBanque_Size = 3;
        public const int CodeAgence_Size = 5;
        public const int RIB_Size = 20;
        public const int CodeCharge = 4;
        public const int DesignationCharge = 40;
        public const int TypeCharge = 10;



        //
        // Summary:
        //     Initializes a new instance of the DevExpress.Xpo.SizeAttribute class.
        //
        // Parameters:
        //   size:
        //     An integer value which specifies the maximum number of characters that can be
        //     stored. This value is assigned to the DevExpress.Xpo.SizeAttribute.Size property.
        public XpertSizeAttribute() { }

        //
        // Summary:
        //     Gets the size of the database column which the member’s data is stored in.
        //
        // Value:
        //     An integer value which specifies the maximum number of characters that can be
        //     stored.
        [Description("Gets the size of the database column which the member’s data is stored in.")]
        public int Size { get; }

    }
}
