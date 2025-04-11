using System;
using System.Collections.Generic;
using Project.Scripts.View.Sync.Abstract;
using Object = UnityEngine.Object;

namespace Project.Scripts.Controller.SyncView.Abstract
{
    //controller abstract from sync objects in scene
    public abstract class SyncControllerAbstract<T>
    {
        #region Variables

        // T components
        protected SyncComponentAbstract<T>[] Components;
        
        // Mapping dictionary from load components
        // int => group id from sync
        // T[] => all components T same group id
        protected Dictionary<int, SyncComponentAbstract<T>[]> MappingDictionary; 
       
        #endregion

        #region Initialization
        
        public virtual void Init()
        {
            // Finding all components type T
            Components = Object.FindObjectsOfType<SyncComponentAbstract<T>>();
            if (Components == null || Components.Length == 0)
                throw new Exception($"Components type[ { typeof(T) } ] not found");

            // Creating Mapping dictionary from all finder components T
            MappingDictionary = GetComponentMappings(Components);
            if (MappingDictionary == null || MappingDictionary.Count == 0)
                throw new Exception("MappingDictionary failed");
        }

        // Mapping Dictionary
        private Dictionary<int, SyncComponentAbstract<T>[]> GetComponentMappings(SyncComponentAbstract<T>[] findingComponents)
        {
            Dictionary<int,SyncComponentAbstract<T>[]> dictionary = new Dictionary<int, SyncComponentAbstract<T>[]>();

            // Mapping is done from non-abstract components
            for (int x = 0; x < findingComponents.Length; x++)
                GetComponentMappings(dictionary, findingComponents, findingComponents[x]);

            return dictionary;
        }
        private void GetComponentMappings(Dictionary<int, SyncComponentAbstract<T>[]> dictionary, SyncComponentAbstract<T>[] findingComponents,
            SyncComponentAbstract<T> component)
        {
            // if ID contains in dictionary => exit 
            if (dictionary.ContainsKey(component.Id))
                return;
            
            // add ID and component.Id == ID save to dictionary
            List<SyncComponentAbstract<T>> list = new List<SyncComponentAbstract<T>>();
            list.Add(component);
            
            for (int y = 0; y < findingComponents.Length; y++)
                if (component != findingComponents[y] && component.Id == findingComponents[y].Id)
                    list.Add(findingComponents[y]);
	
            dictionary.Add(component.Id, list.ToArray());
        }
        #endregion

        #region Public methods

        // Update components from mapping group by instanceID
        public void UpdateComponentsByT(SyncComponentAbstract<T> component)
        {
            if (component == null)
                throw new Exception("Func[UpdateComponentsByGameObject] component null");
            // Get all components from component.Id in dictionary
            MappingDictionary.TryGetValue(component.Id, out SyncComponentAbstract<T>[] components);

            if (components == null)
                throw new Exception("Func[UpdateComponentsByGameObject] components not found in MappingDictionary");

            // Update components in group
            for (int x = 0; x < components.Length; x++)
                if (components[x] != component)
                    components[x].UpdateByComponentT(component.ComponentSync);
        }

        #endregion
    }
}

