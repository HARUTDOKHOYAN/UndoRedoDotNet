using UndoRedo.Contracts;

namespace UndoRedo.Snapshots;

public class AClassSnapshot : IUndoRedoSnapshot
{
    public int Value{ get; set; }
}
