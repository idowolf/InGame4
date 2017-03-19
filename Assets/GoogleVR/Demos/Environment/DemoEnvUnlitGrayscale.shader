// Copyright 2016 Google Inc. All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

Shader "GoogleVR/Demos/Unlit/Env Unlit Grayscale" {
  Properties {
    _MainTex ("Texture (A)", 2D) = "" {}
  }

  SubShader {
    Tags { "Queue"="Geometry" "RenderType"="Geometry"}

    Pass {
      CGPROGRAM
// Upgrade NOTE: excluded shader from DX11; has structs without semantics (struct appdata members vertex)
#pragma exclude_renderers d3d11
      #pragma vertex vert
      #pragma fragment frag
      #pragma target 2.0
      #include "UnityCG.cginc"

      #include "../../Shaders/GvrUnityCompatibility.cginc"

      struct appdata {
        float4 vertex : 
		
		;
        float2 uv : TEXCOORD0;
      };

      struct v2f {
        float2 uv : TEXCOORD0;
        float4 vertex : SV_POSITION;
      };

      sampler2D _MainTex;
      float4 _MainTex_ST;

      v2f vert (appdata v) {
        v2f o;
        o.vertex = GvrUnityObjectToClipPos(v.vertex);
        o.uv = TRANSFORM_TEX(v.uv, _MainTex);
        return o;
      }

      fixed4 frag (v2f i) : SV_TARGET  {
        fixed4 col = tex2D(_MainTex, i.uv).a;
        return col;
      }
      ENDCG
    }
  }
}
