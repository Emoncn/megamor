Shader "Unlit/BlobShader"
{
    Properties{
		_Color("Color", Color) = (1,1,1,1)
 
		_Amount("Amount", Range(0,1)) = 0 //slider
	}

    // no Properties block this time!
    SubShader
    {
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // include file that contains UnityObjectToWorldNormal helper function
            #include "UnityCG.cginc"

            struct v2f {
                // we'll output world space normal as one of regular ("texcoord") interpolators
                half3 worldNormal : TEXCOORD0;
                float4 pos : SV_POSITION;
            };

            float _Amount;
            fixed4 _Color;

            // vertex shader: takes object space normal as input too
            v2f vert (float4 vertex : POSITION, float3 normal : NORMAL)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(vertex) +_Amount * float4(
                    abs(sin(normal.x * 0.8 * _Time.z + normal.y * 0.7 * _Time.z)),
                    abs(sin(normal.y * 0.8 * _Time.z + normal.z * 0.7 * _Time.z)),
                    abs(sin(normal.x * 0.8 * _Time.z + normal.z * 0.7 * _Time.z)),
                    0); //+ float4(norm.xyz, 1) * abs(sin(_Time.z));
                // UnityCG.cginc file contains function to transform
                // normal from object to world space, use that
                o.worldNormal = UnityObjectToWorldNormal(normal);
                return o;
            }
            
            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 c = 0;
                // normal is a 3D vector with xyz components; in -1..1
                // range. To display it as color, bring the range into 0..1
                // and put into red, green, blue components
                c.rgb = _Color + (sin(_Time.z) + 1.0)/10.0;
                return c;
            }
            ENDCG
        }
    }
        FallBack"Diffuse"
}