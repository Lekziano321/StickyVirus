using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeArea : MonoBehaviour
{
        public List<RectTransform> rects = new();

        private static Canvas GetCanvas(Transform t)
        {
            if (t == null) return null;
            return t.TryGetComponent(out Canvas canvas) ? canvas : GetCanvas(t.parent);
        }

        private Rect _lastSafeArea = new();

        private void UpdateAllRect()
        {
            Rect area = Screen.safeArea;
            foreach (RectTransform r in rects)
            {
                Canvas canvas = null;
                if ((canvas = GetCanvas(r)) != null)
                {
                    float sf = 1.0f / canvas.scaleFactor;

                    Vector2 refSize = new Vector2(Screen.width, Screen.height) * sf;

                    r.offsetMin = new Vector2(area.xMin * sf, area.yMin * sf);//new Vector2(sz.xMin, sz.yMin);
                    r.offsetMax = new Vector2(-(refSize.x - (area.xMax * sf)), -(refSize.y - (area.yMax * sf)));
                }
            }
        }

        private bool ShouldUpdateRect
        {
            get
            {
                bool changed = _lastSafeArea != Screen.safeArea;
                if (changed)
                    _lastSafeArea = Screen.safeArea;
                return changed;
            }
        }

        void Start()
        {
            UpdateAllRect();
        }

        void Update()
        {
            if (ShouldUpdateRect) UpdateAllRect();
        }
}

