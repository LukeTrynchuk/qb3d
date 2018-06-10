using UnityEngine;
using UnityEngine.Events;

namespace FireBullet.QBert.General
{
    [System.Serializable]
    public class DynamicFloatEvent : UnityEvent<float> { }

    [System.Serializable]
    public class DynamicIntEvent : UnityEvent<int> { }

    [System.Serializable]
    public class DynamicStringEvent : UnityEvent<string> { }

    [System.Serializable]
    public class DynamicVector2Event : UnityEvent<Vector2> { }

    [System.Serializable]
    public class DynamicVector3Event : UnityEvent<Vector3> { }

    [System.Serializable]
    public class DynamicBoolEvent : UnityEvent<bool> { }

    [System.Serializable]
    public class DynamicGameObjectEvent : UnityEvent<GameObject> {}

    [System.Serializable]
    public class DynamicTransformEvent : UnityEvent<Transform> {}

    [System.Serializable]
    public class DynamicQuaternionEvent : UnityEvent<Quaternion> {}
}

