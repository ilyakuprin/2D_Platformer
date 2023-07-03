namespace JumpOrDie
{
    public class LayersWhereCantJump
    {
        private readonly int[] _layerNoJump = new int[2];

        public LayersWhereCantJump(HashLayers hashLayers)
        {
            _layerNoJump[0] = hashLayers.Water;
            _layerNoJump[1] = hashLayers.NoJump;
        }

        public bool LayersInaccessibleJump(int layer)
        {
            for (int i = 0; i < _layerNoJump.Length; i++)
            {
                if (layer == _layerNoJump[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
