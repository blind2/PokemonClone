using System;

namespace PokemonClone.Model
{
    public interface IEvent
    {
        bool IsFinished();
        void Execute(Action action);

    }
}
