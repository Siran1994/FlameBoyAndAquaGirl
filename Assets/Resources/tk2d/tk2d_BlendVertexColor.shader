Shader "tk2d/BlendVertexColor"
{
  Properties
  {
    _MainTex ("Base (RGB) Trans (A)", 2D) = "white" {}
  }
  SubShader
  {
    Tags
    { 
      "IGNOREPROJECTOR" = "true"
      "QUEUE" = "Transparent"
      "RenderType" = "Transparent"
    }
    LOD 110
    Pass // ind: 1, name: 
    {
      Tags
      { 
        "IGNOREPROJECTOR" = "true"
        "QUEUE" = "Transparent"
        "RenderType" = "Transparent"
      }
      LOD 110
      ZWrite Off
      Cull Off
      Fog
      { 
        Mode  Off
      } 
      Blend SrcAlpha OneMinusSrcAlpha
      GpuProgramID 30732
      // m_ProgramMask = 6
      !!! *******************************************************************************************
      !!! Allow restore shader as UnityLab format - only available for DevX GameRecovery license type
      !!! *******************************************************************************************
      Program "vp"
      {
        SubProgram "gles hw_tier00"
        {
          
          "!!!!GLES
          #version 100
          
          #ifdef VERTEX
          attribute vec4 _glesVertex;
          attribute vec4 _glesColor;
          attribute vec4 _glesMultiTexCoord0;
          uniform highp mat4 unity_ObjectToWorld;
          uniform highp mat4 unity_MatrixVP;
          varying lowp vec4 xlv_COLOR;
          varying highp vec2 xlv_TEXCOORD0;
          void main ()
          {
            highp vec4 tmpvar_1;
            tmpvar_1 = _glesColor;
            lowp vec4 tmpvar_2;
            highp vec4 tmpvar_3;
            tmpvar_3.w = 1.0;
            tmpvar_3.xyz = _glesVertex.xyz;
            tmpvar_2 = tmpvar_1;
            gl_Position = (unity_MatrixVP * (unity_ObjectToWorld * tmpvar_3));
            xlv_COLOR = tmpvar_2;
            xlv_TEXCOORD0 = _glesMultiTexCoord0.xy;
          }
          
          
          #endif
          #ifdef FRAGMENT
          uniform sampler2D _MainTex;
          varying lowp vec4 xlv_COLOR;
          varying highp vec2 xlv_TEXCOORD0;
          void main ()
          {
            lowp vec4 tmpvar_1;
            tmpvar_1 = (texture2D (_MainTex, xlv_TEXCOORD0) * xlv_COLOR);
            gl_FragData[0] = tmpvar_1;
          }
          
          
          #endif
          
          "
        }
        SubProgram "gles hw_tier01"
        {
          
          "!!!!GLES
          #version 100
          
          #ifdef VERTEX
          attribute vec4 _glesVertex;
          attribute vec4 _glesColor;
          attribute vec4 _glesMultiTexCoord0;
          uniform highp mat4 unity_ObjectToWorld;
          uniform highp mat4 unity_MatrixVP;
          varying lowp vec4 xlv_COLOR;
          varying highp vec2 xlv_TEXCOORD0;
          void main ()
          {
            highp vec4 tmpvar_1;
            tmpvar_1 = _glesColor;
            lowp vec4 tmpvar_2;
            highp vec4 tmpvar_3;
            tmpvar_3.w = 1.0;
            tmpvar_3.xyz = _glesVertex.xyz;
            tmpvar_2 = tmpvar_1;
            gl_Position = (unity_MatrixVP * (unity_ObjectToWorld * tmpvar_3));
            xlv_COLOR = tmpvar_2;
            xlv_TEXCOORD0 = _glesMultiTexCoord0.xy;
          }
          
          
          #endif
          #ifdef FRAGMENT
          uniform sampler2D _MainTex;
          varying lowp vec4 xlv_COLOR;
          varying highp vec2 xlv_TEXCOORD0;
          void main ()
          {
            lowp vec4 tmpvar_1;
            tmpvar_1 = (texture2D (_MainTex, xlv_TEXCOORD0) * xlv_COLOR);
            gl_FragData[0] = tmpvar_1;
          }
          
          
          #endif
          
          "
        }
        SubProgram "gles hw_tier02"
        {
          
          "!!!!GLES
          #version 100
          
          #ifdef VERTEX
          attribute vec4 _glesVertex;
          attribute vec4 _glesColor;
          attribute vec4 _glesMultiTexCoord0;
          uniform highp mat4 unity_ObjectToWorld;
          uniform highp mat4 unity_MatrixVP;
          varying lowp vec4 xlv_COLOR;
          varying highp vec2 xlv_TEXCOORD0;
          void main ()
          {
            highp vec4 tmpvar_1;
            tmpvar_1 = _glesColor;
            lowp vec4 tmpvar_2;
            highp vec4 tmpvar_3;
            tmpvar_3.w = 1.0;
            tmpvar_3.xyz = _glesVertex.xyz;
            tmpvar_2 = tmpvar_1;
            gl_Position = (unity_MatrixVP * (unity_ObjectToWorld * tmpvar_3));
            xlv_COLOR = tmpvar_2;
            xlv_TEXCOORD0 = _glesMultiTexCoord0.xy;
          }
          
          
          #endif
          #ifdef FRAGMENT
          uniform sampler2D _MainTex;
          varying lowp vec4 xlv_COLOR;
          varying highp vec2 xlv_TEXCOORD0;
          void main ()
          {
            lowp vec4 tmpvar_1;
            tmpvar_1 = (texture2D (_MainTex, xlv_TEXCOORD0) * xlv_COLOR);
            gl_FragData[0] = tmpvar_1;
          }
          
          
          #endif
          
          "
        }
        SubProgram "gles3 hw_tier00"
        {
          
          "!!!!GLES3
          #ifdef VERTEX
          #version 300 es
          
          uniform 	vec4 hlslcc_mtx4x4unity_ObjectToWorld[4];
          uniform 	vec4 hlslcc_mtx4x4unity_MatrixVP[4];
          in highp vec4 in_POSITION0;
          in highp vec4 in_COLOR0;
          in highp vec2 in_TEXCOORD0;
          out mediump vec4 vs_COLOR0;
          out highp vec2 vs_TEXCOORD0;
          vec4 u_xlat0;
          vec4 u_xlat1;
          void main()
          {
              u_xlat0 = in_POSITION0.yyyy * hlslcc_mtx4x4unity_ObjectToWorld[1];
              u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[0] * in_POSITION0.xxxx + u_xlat0;
              u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[2] * in_POSITION0.zzzz + u_xlat0;
              u_xlat0 = u_xlat0 + hlslcc_mtx4x4unity_ObjectToWorld[3];
              u_xlat1 = u_xlat0.yyyy * hlslcc_mtx4x4unity_MatrixVP[1];
              u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[0] * u_xlat0.xxxx + u_xlat1;
              u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[2] * u_xlat0.zzzz + u_xlat1;
              gl_Position = hlslcc_mtx4x4unity_MatrixVP[3] * u_xlat0.wwww + u_xlat1;
              vs_COLOR0 = in_COLOR0;
              vs_TEXCOORD0.xy = in_TEXCOORD0.xy;
              return;
          }
          
          #endif
          #ifdef FRAGMENT
          #version 300 es
          
          precision highp int;
          uniform lowp sampler2D _MainTex;
          in mediump vec4 vs_COLOR0;
          in highp vec2 vs_TEXCOORD0;
          layout(location = 0) out mediump vec4 SV_Target0;
          mediump vec4 u_xlat16_0;
          lowp vec4 u_xlat10_0;
          void main()
          {
              u_xlat10_0 = texture(_MainTex, vs_TEXCOORD0.xy);
              u_xlat16_0 = u_xlat10_0 * vs_COLOR0;
              SV_Target0 = u_xlat16_0;
              return;
          }
          
          #endif
          
          "
        }
        SubProgram "gles3 hw_tier01"
        {
          
          "!!!!GLES3
          #ifdef VERTEX
          #version 300 es
          
          uniform 	vec4 hlslcc_mtx4x4unity_ObjectToWorld[4];
          uniform 	vec4 hlslcc_mtx4x4unity_MatrixVP[4];
          in highp vec4 in_POSITION0;
          in highp vec4 in_COLOR0;
          in highp vec2 in_TEXCOORD0;
          out mediump vec4 vs_COLOR0;
          out highp vec2 vs_TEXCOORD0;
          vec4 u_xlat0;
          vec4 u_xlat1;
          void main()
          {
              u_xlat0 = in_POSITION0.yyyy * hlslcc_mtx4x4unity_ObjectToWorld[1];
              u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[0] * in_POSITION0.xxxx + u_xlat0;
              u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[2] * in_POSITION0.zzzz + u_xlat0;
              u_xlat0 = u_xlat0 + hlslcc_mtx4x4unity_ObjectToWorld[3];
              u_xlat1 = u_xlat0.yyyy * hlslcc_mtx4x4unity_MatrixVP[1];
              u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[0] * u_xlat0.xxxx + u_xlat1;
              u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[2] * u_xlat0.zzzz + u_xlat1;
              gl_Position = hlslcc_mtx4x4unity_MatrixVP[3] * u_xlat0.wwww + u_xlat1;
              vs_COLOR0 = in_COLOR0;
              vs_TEXCOORD0.xy = in_TEXCOORD0.xy;
              return;
          }
          
          #endif
          #ifdef FRAGMENT
          #version 300 es
          
          precision highp int;
          uniform lowp sampler2D _MainTex;
          in mediump vec4 vs_COLOR0;
          in highp vec2 vs_TEXCOORD0;
          layout(location = 0) out mediump vec4 SV_Target0;
          mediump vec4 u_xlat16_0;
          lowp vec4 u_xlat10_0;
          void main()
          {
              u_xlat10_0 = texture(_MainTex, vs_TEXCOORD0.xy);
              u_xlat16_0 = u_xlat10_0 * vs_COLOR0;
              SV_Target0 = u_xlat16_0;
              return;
          }
          
          #endif
          
          "
        }
        SubProgram "gles3 hw_tier02"
        {
          
          "!!!!GLES3
          #ifdef VERTEX
          #version 300 es
          
          uniform 	vec4 hlslcc_mtx4x4unity_ObjectToWorld[4];
          uniform 	vec4 hlslcc_mtx4x4unity_MatrixVP[4];
          in highp vec4 in_POSITION0;
          in highp vec4 in_COLOR0;
          in highp vec2 in_TEXCOORD0;
          out mediump vec4 vs_COLOR0;
          out highp vec2 vs_TEXCOORD0;
          vec4 u_xlat0;
          vec4 u_xlat1;
          void main()
          {
              u_xlat0 = in_POSITION0.yyyy * hlslcc_mtx4x4unity_ObjectToWorld[1];
              u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[0] * in_POSITION0.xxxx + u_xlat0;
              u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[2] * in_POSITION0.zzzz + u_xlat0;
              u_xlat0 = u_xlat0 + hlslcc_mtx4x4unity_ObjectToWorld[3];
              u_xlat1 = u_xlat0.yyyy * hlslcc_mtx4x4unity_MatrixVP[1];
              u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[0] * u_xlat0.xxxx + u_xlat1;
              u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[2] * u_xlat0.zzzz + u_xlat1;
              gl_Position = hlslcc_mtx4x4unity_MatrixVP[3] * u_xlat0.wwww + u_xlat1;
              vs_COLOR0 = in_COLOR0;
              vs_TEXCOORD0.xy = in_TEXCOORD0.xy;
              return;
          }
          
          #endif
          #ifdef FRAGMENT
          #version 300 es
          
          precision highp int;
          uniform lowp sampler2D _MainTex;
          in mediump vec4 vs_COLOR0;
          in highp vec2 vs_TEXCOORD0;
          layout(location = 0) out mediump vec4 SV_Target0;
          mediump vec4 u_xlat16_0;
          lowp vec4 u_xlat10_0;
          void main()
          {
              u_xlat10_0 = texture(_MainTex, vs_TEXCOORD0.xy);
              u_xlat16_0 = u_xlat10_0 * vs_COLOR0;
              SV_Target0 = u_xlat16_0;
              return;
          }
          
          #endif
          
          "
        }
      }
      Program "fp"
      {
        SubProgram "gles hw_tier00"
        {
          
          "!!!!GLES
          
          
          "
        }
        SubProgram "gles hw_tier01"
        {
          
          "!!!!GLES
          
          
          "
        }
        SubProgram "gles hw_tier02"
        {
          
          "!!!!GLES
          
          
          "
        }
        SubProgram "gles3 hw_tier00"
        {
          
          "!!!!GLES3
          
          
          "
        }
        SubProgram "gles3 hw_tier01"
        {
          
          "!!!!GLES3
          
          
          "
        }
        SubProgram "gles3 hw_tier02"
        {
          
          "!!!!GLES3
          
          
          "
        }
      }
      
    } // end phase
  }
  FallBack ""
}
