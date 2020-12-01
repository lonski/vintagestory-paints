using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vintagestory.API.Client;
using Vintagestory.API.Common;
using Vintagestory.API.Common.Entities;
using Vintagestory.API.MathTools;
using Vintagestory.GameContent;

namespace Paints
{
    class PaintedPlanksRenderer : IRenderer
    {
        ICoreClientAPI api;
        int textureId;
        BlockPos pos;
        MeshRef cubeModelRef;
        protected Matrixf ModelMat = new Matrixf();

        public PaintedPlanksRenderer(Block block, BlockPos pos, ICoreClientAPI api)
        {
            System.Console.WriteLine("XXXX Constr Renderer");
            this.api = api;
            this.textureId = block.Textures.First().Value.Baked.TextureSubId;
            this.pos = pos;
            cubeModelRef = api.Render.UploadMesh(api.TesselatorManager.GetDefaultBlockMesh(block));
            
        }
        public double RenderOrder
        {
            get { return 0.5; }
        }

        public int RenderRange
        {
            get { return 24; }
        }

        public void Dispose()
        {
            api.Event.UnregisterRenderer(this, EnumRenderStage.Opaque);
            cubeModelRef?.Dispose();
        }

        public void OnRenderFrame(float deltaTime, EnumRenderStage stage)
        {
            // IStandardShaderProgram prog = api.Render.PreparedStandardShader(pos.X, pos.Y, pos.Z, new Vec4f(0.1f, 0.1f, 0.1f, 1));

            // prog.ExtraGlow = 5;
            // prog.RgbaTint = new Vec4f(16,16,16,16);

            IRenderAPI rpi = api.Render;
            IStandardShaderProgram prog = rpi.PreparedStandardShader(pos.X, pos.Y, pos.Z);
            Vec3d camPos = api.World.Player.Entity.CameraPos;
            rpi.GlDisableCullFace();
            rpi.GlToggleBlend(true);
            // rpi.BindTexture2d(textureId);
            prog.Tex2D = textureId;

            // prog.ModelMatrix = ModelMat
            //     .Identity()
            //     .Translate(pos.X, pos.Y, pos.Z)
            //     .Values
            // ;
             prog.ModelMatrix = ModelMat
                .Identity()
                .Translate(8 / 16f + pos.X - camPos.X, pos.Y - camPos.Y + 16 / 32f, 8 / 16f + pos.Z - camPos.Z)
                .Values
            ;
            prog.ViewMatrix = rpi.CameraMatrixOriginf;
            prog.ProjectionMatrix = rpi.CurrentProjectionMatrix;
            prog.NormalShaded = 0;

            rpi.RenderMesh(cubeModelRef);
            prog.Stop();

        }
    }
}
