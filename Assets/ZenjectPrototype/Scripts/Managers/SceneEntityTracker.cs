﻿using UnityEngine;
using Zenject;
using ZenjectPrototype.Entities;

namespace ZenjectPrototype.Managers
{
    public class SceneEntityTracker
    {
        private IDataHolder<Entity> entities;

        [Inject]
        public SceneEntityTracker(IDataHolder<Entity> entityHolder)
        {
            this.entities = entityHolder;
        }

        public void Fetch()
        {
            SaveEntities(GetSceneEntities());
        }

        private Entity[] GetSceneEntities()
        {
            return GameObject.FindObjectsOfType<Entity>();
        }

        private void SaveEntities(Entity[] entities)
        {
            foreach(var entity in entities)
            {
                this.entities.Add(entity);
            }
        }
    }
}
