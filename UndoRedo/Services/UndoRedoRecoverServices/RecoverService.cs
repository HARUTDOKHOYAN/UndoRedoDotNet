using UndoRedo.Snapshots;
using UndoRedo.Contracts;
using UndoRedo.Models;

namespace UndoRedo.Services.UndoRedoRecoverServices;

public class AClassRecoverService : IUndoRedoRecoverService<AClassSnapshot>
{
    private AClass _recoverTarget;
    public AClassRecoverService(AClass recoverTarget)
    {
        _recoverTarget = recoverTarget;
    }
    public void Recover(AClassSnapshot snapshot)
    {
        _recoverTarget.Value = snapshot.Value;
    }
}
