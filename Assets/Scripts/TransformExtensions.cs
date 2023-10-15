using UnityEngine;

public static class TransformExtensions
{
    public static Transform SetNewParent(this Transform transform, Transform parent)
    {
        transform.parent = parent;
        return transform;
    }

    public static Transform RemoveParent(this Transform transform)
    {
        transform.parent = null;
        return transform;
    }
        
    public static Transform SetPosition(this Transform transform, in Vector3 value)
    {
        transform.position = value;
        return transform;
    }
        
    public static Transform SetPosition(this Transform transform, float x, float y, float z)
    {
        var position = transform.position;
        position.x = x;
        position.y = y;
        position.z = z;
        transform.position = position;
        return transform;
    }

    public static Transform SetPositionX(this Transform transform, float value)
    {
        var position = transform.position;
        position.x = value;
        transform.position = position;
        return transform;
    }
        
    public static Transform SetPositionY(this Transform transform, float value)
    {
        var position = transform.position;
        position.y = value;
        transform.position = position;
        return transform;
    }
        
    public static Transform SetPositionZ(this Transform transform, float value)
    {
        var position = transform.position;
        position.z = value;
        transform.position = position;
        return transform;
    }
        
    public static Transform SetPositionXY(this Transform transform, float x, float y)
    {
        var position = transform.position;
        position.x = x;
        position.y = y;
        transform.position = position;
        return transform;
    }

    public static Transform SetPositionXY(this Transform target, in Vector2 value)
    {
        var position = target.position;
        position.x = value.x;
        position.y = value.y;
        target.position = position;
        return target;
    }
        
    public static Transform SetPositionXZ(this Transform transform, float x, float z)
    {
        var position = transform.position;
        position.x = x;
        position.z = z;
        transform.position = position;
        return transform;
    }
        
    public static Transform SetPositionYZ(this Transform transform, float y, float z)
    {
        var position = transform.position;
        position.y = y;
        position.z = z;
        transform.position = position;
        return transform;
    }
        
    public static Transform SetLocalPosition(this Transform transform, in Vector3 position)
    {
        transform.localPosition = position;
        return transform;
    }
        
    public static Transform SetLocalPosition(this Transform transform, float x, float y, float z)
    {
        var position = transform.localPosition;
        position.x = x;
        position.y = y;
        position.z = z;
        transform.localPosition = position;
        return transform;
    }

    public static Transform SetLocalPositionX(this Transform transform, float value)
    {
        var position = transform.localPosition;
        position.x = value;
        transform.localPosition = position;
        return transform;
    }
        
    public static Transform SetLocalPositionY(this Transform transform, float value)
    {
        var position = transform.localPosition;
        position.y = value;
        transform.localPosition = position;
        return transform;
    }
        
    public static Transform SetLocalPositionZ(this Transform transform, float value)
    {
        var position = transform.localPosition;
        position.z = value;
        transform.localPosition = position;
        return transform;
    }
        
    public static Transform SetLocalPositionXY(this Transform transform, float x, float y)
    {
        var position = transform.localPosition;
        position.x = x;
        position.y = y;
        transform.localPosition = position;
        return transform;
    }
        
    public static Transform SetLocalPositionXY(this Transform transform, in Vector2 value)
    {
        var position = transform.localPosition;
        position.x = value.x;
        position.y = value.y;
        transform.localPosition = position;
        return transform;
    }
        
    public static Transform SetLocalPositionXZ(this Transform transform, float x, float z)
    {
        var position = transform.localPosition;
        position.x = x;
        position.z = z;
        transform.localPosition = position;
        return transform;
    }
        
    public static Transform SetLocalPositionYZ(this Transform transform, float y, float z)
    {
        var position = transform.localPosition;
        position.y = y;
        position.z = z;
        transform.localPosition = position;
        return transform;
    }

    public static Transform SetLocalScale(this Transform transform, in Vector3 value)
    {
        transform.localScale = value;
        return transform;
    }
        
    public static Transform SetLocalScale(this Transform transform, float x, float y, float z)
    {
        var scale = transform.localScale;
        scale.x = x;
        scale.y = y;
        scale.z = z;
        transform.localScale = scale;
        return transform;
    }

    public static Transform SetLocalScaleX(this Transform transform, float value)
    {
        var scale = transform.localScale;
        scale.x = value;
        transform.localScale = scale;
        return transform;
    }
        
    public static Transform SetLocalScaleY(this Transform transform, float value)
    {
        var scale = transform.localScale;
        scale.y = value;
        transform.localScale = scale;
        return transform;
    }
        
    public static Transform SetLocalScaleZ(this Transform transform, float value)
    {
        var scale = transform.localScale;
        scale.z = value;
        transform.localScale = scale;
        return transform;
    }

    public static Transform SetLocalScaleXY(this Transform target, float value)
    {
        return target.SetLocalScaleXY(value, value);
    }

    public static Transform SetLocalScaleXY(this Transform target, in Vector2 value)
    {
        return target.SetLocalScaleXY(value.x, value.y);
    }
        
    public static Transform SetLocalScaleXY(this Transform transform, float x, float y)
    {
        var scale = transform.localScale;
        scale.x = x;
        scale.y = y;
        transform.localScale = scale;
        return transform;
    }
        
    public static Transform SetLocalScaleXZ(this Transform transform, float x, float z)
    {
        var scale = transform.localScale;
        scale.x = x;
        scale.z = z;
        transform.localScale = scale;
        return transform;
    }
        
    public static Transform SetLocalScaleYZ(this Transform transform, float y, float z)
    {
        var scale = transform.localScale;
        scale.y = y;
        scale.z = z;
        transform.localScale = scale;
        return transform;
    }

    public static Transform SetLocalRotation(this Transform transform, in Quaternion quaternion)
    {
        transform.localRotation = quaternion;
        return transform;
    }

    public static Transform SetLocalRotation(this Transform transform, in Vector3 euler)
    {
        transform.localRotation = Quaternion.Euler(euler);
        return transform;
    }

    public static Transform SetLocalRotation(this Transform transform, float x, float y, float z)
    {
        transform.localRotation = Quaternion.Euler(x, y, z);
        return transform;
    }

    public static Transform SetLocalRotationX(this Transform transform, float value)
    {
        var euler = transform.localRotation.eulerAngles;
        euler.x = value;
        transform.localRotation = Quaternion.Euler(euler);
        return transform;
    }
        
    public static Transform SetLocalRotationY(this Transform transform, float value)
    {
        var euler = transform.localRotation.eulerAngles;
        euler.y = value;
        transform.localRotation = Quaternion.Euler(euler);
        return transform;
    }
        
    public static Transform SetLocalRotationZ(this Transform transform, float value)
    {
        var euler = transform.localRotation.eulerAngles;
        euler.z = value;
        transform.localRotation = Quaternion.Euler(euler);
        return transform;
    }
}