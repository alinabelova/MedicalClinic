using System.ComponentModel.Composition;
using Mita.DataAccess;
using Mita.DataAccess.EF;

namespace MedicalClinic
{
    [Export(typeof(IRepositoryProvider))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class MedicalClinicRepositoryPorvider : EntityRepositoryProvider<Db>
    {
    }
}
