using Dreamteck.Splines;
using Project.Scripts.GamePlay;
using Project.Scripts.UI.DrawUI;
using UnityEngine;

namespace Project.Scripts.Architecture.Factories
{
    public interface IGameFactory
    {
        public void InitOnScene();

        public CrowdFacade CreateCrowd(IDrawInput drawInput);

        public void RebuildCrowd();
    }
}