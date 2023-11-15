using Niantic.Lightship.Maps.Builders.Standard.Objects;
using Niantic.Lightship.Maps.Core;
using Niantic.Lightship.Maps.Core.Features;
using Niantic.Lightship.Maps.Utilities;
using Niantic.Platform.Debugging;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

/// <summary>
/// This is a script that extends AreaObjectBuilder but adds funtionality to randomize positioning
/// </summary>
public class RandomizedObjectBuilder : AreaObjectBuilder
{
    [SerializeField] private float maxOffset = 0.5f;
    [SerializeField][Range(0, 1f)] private float chanceToSpawn = 1f;

    protected override void BuildFeature(IMapTile mapTile, GameObject parent, IMapTileFeature feature)
    {
        float randomNumber = Random.Range(0, 1f);
        if (randomNumber <= chanceToSpawn)
        {
            base.BuildFeature(mapTile, parent, feature);
        }
    }

    /// <inheritdoc />
    protected override Vector3 GetObjectPosition(IMapTileFeature feature)
    {


        if (feature is not IAreaFeature areaFeature)
        {
            // This method should only be called for area features,
            // so if we somehow got a different feature type, log
            // an error and return a default value of Vector3.zero.

            var type = feature.GetType().Name;
            Log.Error($"Feature '{type}' is not an area feature!");
            return Vector3.zero;
        }

        Vector2 randomVector = Random.insideUnitCircle * maxOffset;

        // Return the area feature's centroid for our object's position
        return MeshBuilderUtils.CalculateCentroid(areaFeature.Points) + new Vector3(randomVector.x, 0, randomVector.y);
    }
}
