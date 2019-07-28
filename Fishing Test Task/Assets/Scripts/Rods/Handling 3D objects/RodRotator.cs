using UnityEngine;
using UnityEngine.EventSystems;

namespace FishingTestTask
{
    public class RodRotator : MonoBehaviour
    {
        [SerializeField] private float _rotSpeed = 0.5f;
        [SerializeField] private float _dir = -1;
        [SerializeField] private Transform _rotationRod;

        private float _rotY = 0f;
        private Vector3 _originRot;

        void Start()
        {
            _originRot = _rotationRod.eulerAngles;
            _rotY = _originRot.y;

            EventTrigger trigger = GetComponent<EventTrigger>();

            EventTrigger.Entry entry = new EventTrigger.Entry();
            entry.eventID = EventTriggerType.Drag;
            entry.callback.AddListener((data) => { OnDragDelegate((PointerEventData)data); });
            trigger.triggers.Add(entry);
        }

        public void OnDragDelegate(PointerEventData data)
        {
                _rotY += data.delta.x * Time.deltaTime * _rotSpeed * _dir;
                _rotationRod.eulerAngles = new Vector3(0f, _rotY, 0f);

        }

    }

}
