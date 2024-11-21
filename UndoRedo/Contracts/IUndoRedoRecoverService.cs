using System;

namespace UndoRedo.Contracts;

public interface IUndoRedoRecoverService<T> where T : IUndoRedoSnapshot
{
    void Recover(T snapshot);
}
