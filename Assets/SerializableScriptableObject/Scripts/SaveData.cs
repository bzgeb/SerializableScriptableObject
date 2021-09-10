using UnityEngine;

public class SaveData
{
    public Guid[] EntityGuids;
    public Vector3[] EntityPositions;

    public void SetEntities(Entity[] entities)
    {
        EntityGuids = new Guid[entities.Length];
        EntityPositions = new Vector3[entities.Length];
        for (int i = 0; i < entities.Length; ++i)
        {
            EntityGuids[i] = entities[i].Descriptor.Guid;
            EntityPositions[i] = entities[i].transform.position;
        }
    }
}