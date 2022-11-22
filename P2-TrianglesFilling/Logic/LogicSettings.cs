using P2_TrianglesFilling.Canvases;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace P2_TrianglesFilling.Logic
{
    public class LogicSettings
    {
        public LogicSettings(
            Action<Color> objectColor_setter,
            Action<Color> lightColor_setter,
            Action<float> lightSourcePositionHeight_setter,
            Action<float> lightSourcePositionRadius_setter,
            Action<float> lightSourceAngle_setter,
            Action<ObjectBackground> objectBackground_setter,
            Action<DrawingMethod> drawingMethod_setter,
            Action<int> m_setter,
            Action<float> kS_setter,
            Action<float> kD_setter,
            Action<NormalMappingMethod> normalMappingMethod_setter)
        {
            ObjectColor_setter = objectColor_setter;
            ObjectColor = Color.Orange;

            LightColor_setter = lightColor_setter;
            LightColor = Color.White;

            LightSourcePositionHeight_setter = lightSourcePositionHeight_setter;
            LightSourcePositionHeight = 8f;

            LightSourcePositionRadius_setter = lightSourcePositionRadius_setter;
            LightSourcePositionRadius = 5f;

            LightSourceAngle_setter = lightSourceAngle_setter;
            LightSourcePositionAngle = 0f;

            ObjectBackground_setter = objectBackground_setter;
            ObjectBackground = ObjectBackground.ConstantColor;

            DrawingMethod_setter = drawingMethod_setter;
            DrawingMethod = DrawingMethod.ColorInterpolation;

            M_setter = m_setter;
            M = 5;

            KS_setter = kS_setter;
            KS = 0.5f;

            KD_setter = kD_setter;
            KD = 0.5f;
            NormalMappingMethod_setter = normalMappingMethod_setter;
        }

        private Action<Color> ObjectColor_setter;
        private Color _ObjectColor;
        public Color ObjectColor
        {
            get => _ObjectColor; set
            {
                _ObjectColor = value;
                ObjectColor_setter(value);
            }
        }

        private Action<Color> LightColor_setter;
        private Color _LightColor;
        public Color LightColor
        {
            get => _LightColor; set
            {
                _LightColor = value;
                LightColor_setter(value);
            }
        }

        private Bitmap? _ObjectTexture;
        public Bitmap? ObjectTexture
        {
            get => _ObjectTexture; set
            {
                _ObjectTexture = value;
                ObjectTextureParallel = value == null ? null : new DirectParallelBitmap(value);
            }
        }
        public DirectParallelBitmap? ObjectTextureParallel { get; private set; }


        private Action<float> LightSourcePositionHeight_setter;
        private float _LightSourcePositionHeight;
        public float LightSourcePositionHeight
        {
            get => _LightSourcePositionHeight; set
            {
                _LightSourcePositionHeight = value;
                LightSourcePositionHeight_setter(value);
            }
        }

        private Action<float> LightSourcePositionRadius_setter;
        private float _LightSourcePositionRadius;
        public float LightSourcePositionRadius
        {
            get => _LightSourcePositionRadius; set
            {
                _LightSourcePositionRadius = value;
                LightSourcePositionRadius_setter(value);
            }
        }

        private Action<float> LightSourceAngle_setter;
        private float _LightSourcePositionAngle;
        public float LightSourcePositionAngle
        {
            get => _LightSourcePositionAngle; set
            {
                _LightSourcePositionAngle = (float)((double)value % (2 * Math.PI));
                LightSourceAngle_setter(_LightSourcePositionAngle);
            }
        }

        private Action<float> KD_setter;
        private float _KD;
        public float KD
        {
            get => _KD; set
            {
                _KD = value;
                KD_setter(value);
            }
        }

        private Action<float> KS_setter;
        private float _KS;
        public float KS
        {
            get => _KS; set
            {
                _KS = value;
                KS_setter(value);
            }
        }

        private Action<int> M_setter;
        private int _M = 5;
        public int M
        {
            get => _M; set
            {
                _M = value;
                M_setter(value);
            }
        }

        private Action<ObjectBackground> ObjectBackground_setter;
        private ObjectBackground _ObjectBackground;
        public ObjectBackground ObjectBackground
        {
            get => _ObjectBackground; set
            {
                _ObjectBackground = value;
                ObjectBackground_setter(ObjectBackground);
            }
        }

        private Action<DrawingMethod> DrawingMethod_setter;
        private DrawingMethod _DrawingMethod;

        public DrawingMethod DrawingMethod
        {
            get => _DrawingMethod; set
            {
                _DrawingMethod = value;
                DrawingMethod_setter(DrawingMethod);
            }
        }

        private Action<NormalMappingMethod> NormalMappingMethod_setter;
        private NormalMappingMethod _NormalMappingMethod;
        public NormalMappingMethod NormalMappingMethod { get => _NormalMappingMethod; set
            {
                _NormalMappingMethod = value;
                NormalMappingMethod_setter(value);
            }
        }

        private Bitmap? _NormalMapTexture;
        public Bitmap? NormalMapTexture
        {
            get => _NormalMapTexture; set
            {
                _NormalMapTexture = value;
                NormalMapTextureParallel = value == null ? null : new DirectParallelBitmap(value);
            }
        }
        public DirectParallelBitmap? NormalMapTextureParallel { get; private set; }

        public float CloudOffset { get; set; } = 0;
    }

    public enum NormalMappingMethod { NoMapping, MapFromFile }
    public enum ObjectBackground { ConstantColor, TextureBitmap }
    public enum DrawingMethod { ColorInterpolation, NormalsInterpolation }
}
