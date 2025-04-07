namespace tarot_card_battler.Core
{
    public static class EntityLayerManager
    {
        public static List<int> layers = new List<int>();
        public static Dictionary<int, EntityLayer> entityLayers = new Dictionary<int, EntityLayer>();
        public static void Update()
        {
            foreach (int layer in layers)
            {
                entityLayers[layer].Update();
            }
        }

        public static void RenderAll()
        {
            foreach(int layer in layers)
            {
                entityLayers[layer].Render();
            }
        }

        public static void RenderLayer(int layer)
        {
            if (entityLayers.ContainsKey(layer))
                entityLayers[layer].Render();
        }

        public static void AddEntity(Entity entity, int layer)
        {
            if(!entityLayers.ContainsKey(layer))
            {
                layers.Add(layer);
                entityLayers.Add(layer, new EntityLayer());
                layers.Sort();
            }
            entityLayers[layer].AddEntity(entity);
        }

    }
}
