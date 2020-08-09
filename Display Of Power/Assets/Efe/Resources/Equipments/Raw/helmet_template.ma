//Maya ASCII 2018 scene
//Name: helmet_template.ma
//Last modified: Thu, Aug 06, 2020 11:00:30 PM
//Codeset: 1252
requires maya "2018";
currentUnit -l centimeter -a degree -t film;
fileInfo "application" "maya";
fileInfo "product" "Maya 2018";
fileInfo "version" "2018";
fileInfo "cutIdentifier" "201706261615-f9658c4cfc";
fileInfo "osv" "Microsoft Windows 8 Business Edition, 64-bit  (Build 9200)\n";
fileInfo "license" "student";
createNode transform -s -n "persp";
	rename -uid "5FB1FE73-43C2-884A-BDEA-89A320124E6E";
	setAttr ".v" no;
	setAttr ".t" -type "double3" 30.276607771125914 15.756333837892015 49.11654339274056 ;
	setAttr ".r" -type "double3" -5.1383527296026088 31.400000000000087 0 ;
createNode camera -s -n "perspShape" -p "persp";
	rename -uid "5C03FB90-475B-39A5-7BCC-84BAD1498C6C";
	setAttr -k off ".v" no;
	setAttr ".fl" 34.999999999999993;
	setAttr ".coi" 58.345888673797688;
	setAttr ".imn" -type "string" "persp";
	setAttr ".den" -type "string" "persp_depth";
	setAttr ".man" -type "string" "persp_mask";
	setAttr ".tp" -type "double3" 1.7320025325062716e-07 10.530817219703934 -0.48450229754187557 ;
	setAttr ".hc" -type "string" "viewSet -p %camera";
	setAttr ".ai_translator" -type "string" "perspective";
createNode transform -s -n "top";
	rename -uid "D6A2D787-4F10-C952-6561-28B05ED60BED";
	setAttr ".v" no;
	setAttr ".t" -type "double3" 0 1000.1 0 ;
	setAttr ".r" -type "double3" -89.999999999999986 0 0 ;
createNode camera -s -n "topShape" -p "top";
	rename -uid "CBE5E77E-4FEC-916D-291B-CB96885578DA";
	setAttr -k off ".v" no;
	setAttr ".rnd" no;
	setAttr ".coi" 1000.1;
	setAttr ".ow" 30;
	setAttr ".imn" -type "string" "top";
	setAttr ".den" -type "string" "top_depth";
	setAttr ".man" -type "string" "top_mask";
	setAttr ".hc" -type "string" "viewSet -t %camera";
	setAttr ".o" yes;
	setAttr ".ai_translator" -type "string" "orthographic";
createNode transform -s -n "front";
	rename -uid "33E625E1-4769-DA88-7674-2CB69184A172";
	setAttr ".v" no;
	setAttr ".t" -type "double3" 0 0 1000.1 ;
createNode camera -s -n "frontShape" -p "front";
	rename -uid "B9E60E69-4AA1-1EF8-F9C0-B2B5B0D5B953";
	setAttr -k off ".v" no;
	setAttr ".rnd" no;
	setAttr ".coi" 1000.1;
	setAttr ".ow" 30;
	setAttr ".imn" -type "string" "front";
	setAttr ".den" -type "string" "front_depth";
	setAttr ".man" -type "string" "front_mask";
	setAttr ".hc" -type "string" "viewSet -f %camera";
	setAttr ".o" yes;
	setAttr ".ai_translator" -type "string" "orthographic";
createNode transform -s -n "side";
	rename -uid "E114BFD1-4134-55FB-CDA4-B8991378EC42";
	setAttr ".v" no;
	setAttr ".t" -type "double3" 1000.1 0 0 ;
	setAttr ".r" -type "double3" 0 89.999999999999986 0 ;
createNode camera -s -n "sideShape" -p "side";
	rename -uid "9BA9E8CB-4C6D-BAF5-E97F-B6A39A210B1C";
	setAttr -k off ".v" no;
	setAttr ".rnd" no;
	setAttr ".coi" 1000.1;
	setAttr ".ow" 30;
	setAttr ".imn" -type "string" "side";
	setAttr ".den" -type "string" "side_depth";
	setAttr ".man" -type "string" "side_mask";
	setAttr ".hc" -type "string" "viewSet -s %camera";
	setAttr ".o" yes;
	setAttr ".ai_translator" -type "string" "orthographic";
createNode transform -n "group";
	rename -uid "41724FA6-47A7-46C3-2CBC-5294C49012CD";
	setAttr ".t" -type "double3" 0 -154.51565151095349 0 ;
	setAttr ".rp" -type "double3" 1.7320025325062716e-07 165.04646873065741 -0.48450229754187557 ;
	setAttr ".sp" -type "double3" 1.7320025325062716e-07 165.04646873065741 -0.48450229754187557 ;
createNode transform -n "pasted__pSphere4" -p "group";
	rename -uid "A41AE3A9-49DB-6B43-54F1-D8B7FD07103B";
	setAttr ".t" -type "double3" 0.20639943945613259 159.59345316348387 -0.781042882911549 ;
	setAttr ".s" -type "double3" 0.36880662583717488 0.55902206125733989 0.42929040159457876 ;
createNode mesh -n "pasted__pSphereShape4" -p "pasted__pSphere4";
	rename -uid "91444AF0-4715-E0C2-F3E8-31AFE1C5800F";
	setAttr -k off ".v";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
	setAttr ".dr" 3;
	setAttr ".dsm" 2;
	setAttr ".ai_translator" -type "string" "polymesh";
createNode lightLinker -s -n "lightLinker1";
	rename -uid "83B0C820-42B5-C041-9DF7-BEAEE11BC372";
	setAttr -s 2 ".lnk";
	setAttr -s 2 ".slnk";
createNode shapeEditorManager -n "shapeEditorManager";
	rename -uid "495FB13D-4452-2381-5546-5A986271AE95";
createNode poseInterpolatorManager -n "poseInterpolatorManager";
	rename -uid "62AF5AF6-4623-07BC-516C-04A98578FACD";
createNode displayLayerManager -n "layerManager";
	rename -uid "EDCB276D-4DDA-1B67-AB1D-66AC36DC0A17";
createNode displayLayer -n "defaultLayer";
	rename -uid "492B4C79-45BF-5A87-BEA1-F6B4B62973FB";
createNode renderLayerManager -n "renderLayerManager";
	rename -uid "08C4C0D0-4A7B-0F08-AF43-99B865AC36A3";
createNode renderLayer -n "defaultRenderLayer";
	rename -uid "4BC00794-41BA-F0A2-C902-1FA93EB24A00";
	setAttr ".g" yes;
createNode polyMirror -n "pasted__polyMirror9";
	rename -uid "A56FD052-46B8-95FC-C71A-C49CEEACA121";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 1 "f[*]";
	setAttr ".ix" -type "matrix" 0.36880662583717488 0 0 0 0 0.55902206125733989 0 0
		 0 0 0.42929040159457876 0 0.20639943945613259 159.59345316348387 -0.781042882911549 1;
	setAttr ".ws" yes;
	setAttr ".mtt" 1;
	setAttr ".mt" 9.3835763931274414;
	setAttr ".cm" yes;
	setAttr ".fnf" 160;
	setAttr ".lnf" 319;
createNode deleteComponent -n "pasted__deleteComponent116";
	rename -uid "BE83652B-4569-DED8-0D4F-21A0A31DC054";
	setAttr ".dc" -type "componentList" 26 "f[4:11]" "f[19:26]" "f[34:41]" "f[49:56]" "f[64:71]" "f[80:89]" "f[100:109]" "f[120:129]" "f[140:149]" "f[160:169]" "f[180:189]" "f[200:209]" "f[216:223]" "f[231:242]" "f[257:267]" "f[277:280]" "f[285:286]" "f[289]" "f[291]" "f[293:294]" "f[297:298]" "f[302:303]" "f[305]" "f[310:312]" "f[316:318]" "f[322:324]";
createNode polyTweak -n "pasted__polyTweak534";
	rename -uid "30B6EA4A-494D-B160-262C-7385605C3858";
	setAttr ".uopa" yes;
	setAttr -s 11 ".tk";
	setAttr ".tk[0]" -type "float3" 0 0 -3.360323 ;
	setAttr ".tk[16]" -type "float3" 0 0 1.483788 ;
	setAttr ".tk[17]" -type "float3" -3.5527137e-15 0 -1.5324855 ;
	setAttr ".tk[33]" -type "float3" 0 0 1.0207684 ;
	setAttr ".tk[34]" -type "float3" 0 0 -0.63282108 ;
	setAttr ".tk[50]" -type "float3" 0 0 1.2135485 ;
	setAttr ".tk[67]" -type "float3" 0 0 1.2135485 ;
	setAttr ".tk[68]" -type "float3" 0 -1.3512281 0 ;
	setAttr ".tk[84]" -type "float3" 0 -1.228832 0 ;
	setAttr ".tk[235]" -type "float3" 3.5527137e-15 0 -2.4746222 ;
	setAttr ".tk[236]" -type "float3" -3.5527137e-15 0 1.4250371 ;
createNode deleteComponent -n "pasted__deleteComponent115";
	rename -uid "C36AA3D8-4D20-79FE-239E-63AB32F0958A";
	setAttr ".dc" -type "componentList" 1 "f[60]";
createNode deleteComponent -n "pasted__deleteComponent114";
	rename -uid "58FBAFB8-4F5F-70B9-C792-FFA2D123E2EF";
	setAttr ".dc" -type "componentList" 1 "f[45]";
createNode deleteComponent -n "pasted__deleteComponent113";
	rename -uid "C8DD13B7-4A83-3BCB-9C71-1AA972405A0B";
	setAttr ".dc" -type "componentList" 1 "f[15]";
createNode deleteComponent -n "pasted__deleteComponent112";
	rename -uid "CDD299E0-4DF6-A2C1-68D6-59B7600C3B8F";
	setAttr ".dc" -type "componentList" 1 "f[231]";
createNode deleteComponent -n "pasted__deleteComponent111";
	rename -uid "D185EF16-4097-799E-301F-D9B7DB281851";
	setAttr ".dc" -type "componentList" 1 "f[31]";
createNode polyTweak -n "pasted__polyTweak533";
	rename -uid "5F1747E0-4C2A-CEE6-6D42-C6B3A3018952";
	setAttr ".uopa" yes;
	setAttr -s 30 ".tk";
	setAttr ".tk[98]" -type "float3" 5.6636968 0 0 ;
	setAttr ".tk[100]" -type "float3" -5.6636968 0 0 ;
	setAttr ".tk[289]" -type "float3" 5.6636968 0 0 ;
	setAttr ".tk[294]" -type "float3" -5.6636968 0 0 ;
	setAttr ".tk[313]" -type "float3" 5.6636968 0 0 ;
	setAttr ".tk[315]" -type "float3" -5.6636968 0 0 ;
	setAttr ".tk[316]" -type "float3" -2.8421709e-14 0 0 ;
	setAttr ".tk[317]" -type "float3" -2.8421709e-14 0 0 ;
	setAttr ".tk[318]" -type "float3" 5.6636939 0 0 ;
	setAttr ".tk[319]" -type "float3" 5.6636939 0 0 ;
	setAttr ".tk[320]" -type "float3" -5.6636939 0 0 ;
	setAttr ".tk[321]" -type "float3" -5.6636939 0 0 ;
	setAttr ".tk[322]" -type "float3" -2.8421709e-14 0 0 ;
	setAttr ".tk[323]" -type "float3" -2.8421709e-14 0 0 ;
	setAttr ".tk[324]" -type "float3" -6.580379 0 0 ;
	setAttr ".tk[325]" -type "float3" -6.580379 0 0 ;
	setAttr ".tk[326]" -type "float3" 6.5803785 0 0 ;
	setAttr ".tk[327]" -type "float3" 6.5803785 0 0 ;
	setAttr ".tk[328]" -type "float3" -2.8421709e-14 0 0 ;
	setAttr ".tk[329]" -type "float3" -2.8421709e-14 0 0 ;
	setAttr ".tk[330]" -type "float3" -4.4659662 0 0 ;
	setAttr ".tk[331]" -type "float3" -4.4659662 0 0 ;
	setAttr ".tk[332]" -type "float3" 4.4659657 0 0 ;
	setAttr ".tk[333]" -type "float3" 4.4659657 0 0 ;
	setAttr ".tk[334]" -type "float3" -2.8421709e-14 -1.9565934 0.7409085 ;
	setAttr ".tk[335]" -type "float3" -2.8421709e-14 -1.9565934 0.7409085 ;
	setAttr ".tk[336]" -type "float3" -4.4659662 -1.9565934 0.7409085 ;
	setAttr ".tk[337]" -type "float3" -4.4659662 -1.9565934 0.7409085 ;
	setAttr ".tk[338]" -type "float3" 4.4659657 -1.9565934 0.7409085 ;
	setAttr ".tk[339]" -type "float3" 4.4659657 -1.9565934 0.7409085 ;
createNode polyExtrudeFace -n "pasted__polyExtrudeFace20";
	rename -uid "8D58C0A1-4FBD-796C-E86D-C59125342AE5";
	setAttr ".ics" -type "componentList" 1 "f[306:307]";
	setAttr ".ix" -type "matrix" 0.36880662583717488 0 0 0 0 0.55902206125733989 0 0
		 0 0 0.42929040159457876 0 0.20639943945613259 159.59345316348387 -0.781042882911549 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" 0.20639926 160.5553 11.256961 ;
	setAttr ".rs" 48593;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" -2.8366621653682063 160.4637609041483 10.899592370639494 ;
	setAttr ".cbx" -type "double3" 3.2494606925590648 160.6468488180098 11.614329348869607 ;
createNode polyTweak -n "pasted__polyTweak532";
	rename -uid "E6F7EA2A-449E-701E-0958-B98DD96ED71D";
	setAttr ".uopa" yes;
	setAttr -s 6 ".tk[328:333]" -type "float3"  0 -1.63941884 1.055930495
		 0 -1.63941884 1.055930495 0 -1.63941884 1.055930495 0 -1.63941884 1.055930495 0 -1.63941884
		 1.055930495 0 -1.63941884 1.055930495;
createNode polyExtrudeFace -n "pasted__polyExtrudeFace19";
	rename -uid "F774EC59-40D0-C48E-4B99-038A1D9543B8";
	setAttr ".ics" -type "componentList" 1 "f[306:307]";
	setAttr ".ix" -type "matrix" 0.36880662583717488 0 0 0 0 0.55902206125733989 0 0
		 0 0 0.42929040159457876 0 0.20639943945613259 159.59345316348387 -0.781042882911549 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" 0.20639926 161.47176 10.803659 ;
	setAttr ".rs" 46605;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" -2.8366621653682063 161.38021514357806 10.446291288395425 ;
	setAttr ".cbx" -type "double3" 3.2494606925590648 161.56330305743955 11.161027447819079 ;
createNode polyExtrudeFace -n "pasted__polyExtrudeFace18";
	rename -uid "198D8F8A-42B6-06D4-2D04-EEB106EB3891";
	setAttr ".ics" -type "componentList" 1 "f[306:307]";
	setAttr ".ix" -type "matrix" 0.36880662583717488 0 0 0 0 0.55902206125733989 0 0
		 0 0 0.42929040159457876 0 0.20639943945613259 159.59345316348387 -0.781042882911549 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" 0.20639908 162.62448 10.033292 ;
	setAttr ".rs" 36703;
	setAttr ".lt" -type "double3" -9.7144514654701197e-16 -0.25898615594417895 1.3733903119447388 ;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" -2.6605881429443117 162.5329422449299 9.6759245992348024 ;
	setAttr ".cbx" -type "double3" 3.0733863184137631 162.7160301587914 10.390659939851993 ;
createNode polyBevel3 -n "pasted__polyBevel6";
	rename -uid "4FF771AF-4056-5FDF-1D2E-E39B2DF32D7E";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 2 "e[621]" "e[627]";
	setAttr ".ix" -type "matrix" 0.36880662583717488 0 0 0 0 0.55902206125733989 0 0
		 0 0 0.42929040159457876 0 0.20639943945613259 159.59345316348387 -0.781042882911549 1;
	setAttr ".ws" yes;
	setAttr ".oaf" yes;
	setAttr ".at" 180;
	setAttr ".sn" yes;
	setAttr ".mv" yes;
	setAttr ".mvt" 0.0001;
	setAttr ".sa" 30;
createNode polyTweak -n "pasted__polyTweak531";
	rename -uid "FF59C68C-4B3B-74F3-5A2A-208DD7425814";
	setAttr ".uopa" yes;
	setAttr -s 7 ".tk";
	setAttr ".tk[292]" -type "float3" 0 -2.3841858e-07 0 ;
	setAttr ".tk[313]" -type "float3" 0 -7.5596104 0 ;
	setAttr ".tk[314]" -type "float3" 0 -7.5596104 0 ;
	setAttr ".tk[315]" -type "float3" 0 -7.5596104 0 ;
	setAttr ".tk[316]" -type "float3" 0 -7.5596113 0 ;
	setAttr ".tk[317]" -type "float3" 0 -7.5596113 0 ;
	setAttr ".tk[318]" -type "float3" 0 -7.5596113 0 ;
createNode polyExtrudeFace -n "pasted__polyExtrudeFace17";
	rename -uid "92A311DD-4784-3D27-ED91-499756725960";
	setAttr ".ics" -type "componentList" 2 "f[285]" "f[287]";
	setAttr ".ix" -type "matrix" 0.36880662583717488 0 0 0 0 0.55902206125733989 0 0
		 0 0 0.42929040159457876 0 0.20639943945613259 159.59345316348387 -0.781042882911549 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" 0.20639908 166.75888 9.9401836 ;
	setAttr ".rs" 63773;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" -2.6605881429443117 166.7588747032446 9.4897091775546496 ;
	setAttr ".cbx" -type "double3" 3.0733863184137631 166.7588747032446 10.390657483432612 ;
createNode polyExtrudeFace -n "pasted__polyExtrudeFace16";
	rename -uid "38135DA8-4CB8-4428-D6B2-B796B25B1E14";
	setAttr ".ics" -type "componentList" 4 "f[113:114]" "f[133:134]" "f[153:154]" "f[173:174]";
	setAttr ".ix" -type "matrix" 0.36880662583717488 0 0 0 0 0.55902206125733989 0 0
		 0 0 0.42929040159457876 0 0.20639943945613259 159.59345316348387 -0.781042882911549 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" 0.20639908 171.73732 5.9027805 ;
	setAttr ".rs" 54880;
	setAttr ".lt" -type "double3" 2.9715813143482706e-15 1.6778245459647678e-14 -0.17104002160152471 ;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" -2.3967708846134839 168.87054437244541 2.7810374736767152 ;
	setAttr ".cbx" -type "double3" 2.8095690600829357 174.60410310021302 9.0245231195355391 ;
createNode polyTweak -n "pasted__polyTweak530";
	rename -uid "B171DB31-4C67-E162-3013-08BD08F3676B";
	setAttr ".uopa" yes;
	setAttr -s 40 ".tk[291:330]" -type "float3"  -1.1920929e-07 7.4505806e-09
		 0.86745715 1.1920929e-07 7.4505806e-09 0.86745727 0 0 0.86745727 0 0 0.86745727 -1.1920929e-07
		 7.4505806e-09 0.86745727 0 0 0.86745727 5.9604645e-08 7.4505806e-09 0.86745739 0
		 0 0.86745715 0 7.4505806e-09 0.86745715 0 0 0.86745739 0 7.4505806e-09 -1.1920929e-07
		 -5.9604645e-08 7.4505806e-09 -1.1920929e-07 0 0 -1.7881393e-07 0 0 -1.1920929e-07
		 7.1054274e-15 7.4505806e-09 1.1920929e-07 5.3290705e-15 0 -1.1920929e-07 -5.9604645e-08
		 7.4505806e-09 -1.1920929e-07 5.9604645e-08 0 -1.7881393e-07 -1.1920929e-07 7.4505806e-09
		 -1.1920929e-07 5.9604645e-08 0 -1.1920929e-07 1.1920929e-07 7.4505806e-09 -1.7881393e-07
		 0 0 -5.9604645e-08 1.1920929e-07 7.4505806e-09 -5.9604645e-08 2.3841858e-07 7.4505806e-09
		 -8.9406967e-08 2.3841858e-07 0 -2.9802322e-08 1.1920929e-07 0 0 -1.1920929e-07 7.4505806e-09
		 7.4505806e-09 1.1920929e-07 0 7.4505806e-09 -1.1920929e-07 7.4505806e-09 0 -1.7881393e-07
		 0 2.9802322e-08 0 0 7.4505806e-09 0 0 2.9802322e-08 5.9604645e-08 0 0 5.9604645e-08
		 0 5.9604645e-08 -1.1920929e-07 0 -1.1920929e-07 -5.9604645e-08 0 -1.1920929e-07 2.9802322e-08
		 0 -1.1920929e-07 5.9604645e-08 0 -1.1920929e-07 2.220446e-16 0 -1.1920929e-07 2.220446e-16
		 0 -1.1920929e-07;
createNode polyExtrudeFace -n "pasted__polyExtrudeFace15";
	rename -uid "3C116178-4CC9-6994-DB1F-A08C34837F78";
	setAttr ".ics" -type "componentList" 1 "f[92:95]";
	setAttr ".ix" -type "matrix" 0.36880662583717488 0 0 0 0 0.55902206125733989 0 0
		 0 0 0.42929040159457876 0 0.20639943945613259 159.59345316348387 -0.781042882911549 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" 0.20639892 167.37628 8.7519512 ;
	setAttr ".rs" 63370;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" -5.2469351045454662 166.75883791762081 7.4856386062022384 ;
	setAttr ".cbx" -type "double3" 5.6597329282935096 167.99372970809287 10.018264305169492 ;
createNode polyMapDel -n "pasted__polyMapDel6";
	rename -uid "4B834293-4A92-CCF1-0C92-1585A99F27EC";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 1 "f[*]";
createNode polySplitRing -n "pasted__polySplitRing19";
	rename -uid "7454F24E-4CFC-CD7A-EFB4-049A88CC4DDE";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 3 "e[305:324]" "e[492]" "e[517]";
	setAttr ".ix" -type "matrix" 0.426108041488649 0 0 0 0 0.55902206125733989 0 0 0 0 0.58428856959580922 0
		 0.20639943945613259 159.59345316348387 -3.0029081683803316 1;
	setAttr ".wt" 0.58478671312332153;
	setAttr ".re" 321;
	setAttr ".sma" 29.999999999999996;
	setAttr ".p[0]"  0 0 1;
	setAttr ".fq" yes;
createNode polySplitRing -n "pasted__polySplitRing18";
	rename -uid "D46EAD4A-4580-4EE4-3345-6699D5009220";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 13 "e[12]" "e[28]" "e[44]" "e[60]" "e[76]" "e[96]" "e[116]" "e[136]" "e[156]" "e[176]" "e[196]" "e[216]" "e[477]";
	setAttr ".ix" -type "matrix" 0.426108041488649 0 0 0 0 0.55902206125733989 0 0 0 0 0.58428856959580922 0
		 0.20639943945613259 159.59345316348387 -3.0029081683803316 1;
	setAttr ".wt" 0.18451277911663055;
	setAttr ".re" 96;
	setAttr ".sma" 29.999999999999996;
	setAttr ".p[0]"  0 0 1;
	setAttr ".fq" yes;
createNode polySplitRing -n "pasted__polySplitRing17";
	rename -uid "2A4321C0-48B1-97B3-6E2D-2E9788898F63";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 13 "e[11]" "e[27]" "e[43]" "e[59]" "e[75]" "e[91]" "e[111]" "e[131]" "e[151]" "e[171]" "e[191]" "e[211]" "e[447]";
	setAttr ".ix" -type "matrix" 0.426108041488649 0 0 0 0 0.55902206125733989 0 0 0 0 0.58428856959580922 0
		 0.20639943945613259 159.59345316348387 -3.0029081683803316 1;
	setAttr ".wt" 0.8931887149810791;
	setAttr ".dr" no;
	setAttr ".re" 11;
	setAttr ".sma" 29.999999999999996;
	setAttr ".p[0]"  0 0 1;
	setAttr ".fq" yes;
createNode polySplitRing -n "pasted__polySplitRing16";
	rename -uid "8BD658BD-46B6-8D30-8FEF-938025F9653F";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 1 "e[220:236]";
	setAttr ".ix" -type "matrix" 0.426108041488649 0 0 0 0 0.55902206125733989 0 0 0 0 0.58428856959580922 0
		 0.20639943945613259 159.59345316348387 -3.0029081683803316 1;
	setAttr ".wt" 0.27499100565910339;
	setAttr ".re" 232;
	setAttr ".sma" 29.999999999999996;
	setAttr ".p[0]"  0 0 1;
	setAttr ".fq" yes;
createNode deleteComponent -n "pasted__deleteComponent110";
	rename -uid "DE24AFD2-4EB5-627B-563F-DEB6DEF5A172";
	setAttr ".dc" -type "componentList" 1 "f[12]";
createNode deleteComponent -n "pasted__deleteComponent109";
	rename -uid "56447451-4B07-6880-7A7B-A69BAC514949";
	setAttr ".dc" -type "componentList" 1 "f[29]";
createNode deleteComponent -n "pasted__deleteComponent108";
	rename -uid "65626EE1-4890-5C06-E2E6-50A2B2F2BE01";
	setAttr ".dc" -type "componentList" 1 "f[46]";
createNode deleteComponent -n "pasted__deleteComponent107";
	rename -uid "A972CBCA-4EBF-AD1F-D695-EA8FCA419F82";
	setAttr ".dc" -type "componentList" 1 "f[63]";
createNode deleteComponent -n "pasted__deleteComponent106";
	rename -uid "8B0296EB-42B6-E594-E673-03B684105416";
	setAttr ".dc" -type "componentList" 1 "f[80]";
createNode deleteComponent -n "pasted__deleteComponent105";
	rename -uid "0FD77B26-4E08-AC16-989B-79AE0B4392F8";
	setAttr ".dc" -type "componentList" 1 "f[12]";
createNode deleteComponent -n "pasted__deleteComponent104";
	rename -uid "A7BEFD6E-41E2-67A8-26C8-E694930417B3";
	setAttr ".dc" -type "componentList" 1 "f[30]";
createNode deleteComponent -n "pasted__deleteComponent103";
	rename -uid "17D0A4BA-4BC4-F5FA-434F-3098FCBA5BDB";
	setAttr ".dc" -type "componentList" 1 "f[48]";
createNode deleteComponent -n "pasted__deleteComponent102";
	rename -uid "F327AFEE-4721-2032-8E00-E085C42CF6D5";
	setAttr ".dc" -type "componentList" 1 "f[66]";
createNode deleteComponent -n "pasted__deleteComponent101";
	rename -uid "1FC8C332-49AC-5891-27C9-2E9E154061DB";
	setAttr ".dc" -type "componentList" 1 "f[84]";
createNode deleteComponent -n "pasted__deleteComponent100";
	rename -uid "C8CD5CF1-4E87-33AF-5EA8-3EA663810568";
	setAttr ".dc" -type "componentList" 1 "f[85]";
createNode deleteComponent -n "pasted__deleteComponent99";
	rename -uid "48E28C48-4BB2-7C99-A64D-8D812ECFA6DD";
	setAttr ".dc" -type "componentList" 1 "f[86]";
createNode deleteComponent -n "pasted__deleteComponent98";
	rename -uid "D02AB050-4F5C-FD8B-94FE-0AABE934686B";
	setAttr ".dc" -type "componentList" 1 "f[67]";
createNode deleteComponent -n "pasted__deleteComponent97";
	rename -uid "C98407CA-417E-5B3B-332C-EC97FD11E2F2";
	setAttr ".dc" -type "componentList" 1 "f[67]";
createNode deleteComponent -n "pasted__deleteComponent96";
	rename -uid "14EF2F44-4EDB-D39C-27B9-328C1007F2CC";
	setAttr ".dc" -type "componentList" 1 "f[49]";
createNode deleteComponent -n "pasted__deleteComponent95";
	rename -uid "F5F969C0-4CD4-56F6-446A-38AA18775227";
	setAttr ".dc" -type "componentList" 1 "f[50]";
createNode deleteComponent -n "pasted__deleteComponent94";
	rename -uid "7A8051FD-44A3-56E3-306C-53828B295F68";
	setAttr ".dc" -type "componentList" 1 "f[31]";
createNode deleteComponent -n "pasted__deleteComponent93";
	rename -uid "F9FA4B96-4AE6-9AC9-DD2D-B0833B1A1AD4";
	setAttr ".dc" -type "componentList" 1 "f[31]";
createNode deleteComponent -n "pasted__deleteComponent92";
	rename -uid "E1B70F99-42A6-F3C6-21C2-A6B543269AF0";
	setAttr ".dc" -type "componentList" 1 "f[13]";
createNode deleteComponent -n "pasted__deleteComponent91";
	rename -uid "18375ABA-405A-9B72-1EB1-01A6C8D006C3";
	setAttr ".dc" -type "componentList" 1 "f[14]";
createNode deleteComponent -n "pasted__deleteComponent90";
	rename -uid "D51B9341-43E7-FF9A-9B9E-84A42027DFD5";
	setAttr ".dc" -type "componentList" 2 "f[0:139]" "f[360:379]";
createNode polySphere -n "pasted__polySphere4";
	rename -uid "0339E72A-46CB-65B9-69BA-93BDD5CEDC74";
	setAttr ".r" 28.233439334341242;
createNode script -n "uiConfigurationScriptNode";
	rename -uid "26AC431A-4D32-BCA7-E47C-B29014413849";
	setAttr ".b" -type "string" (
		"// Maya Mel UI Configuration File.\n//\n//  This script is machine generated.  Edit at your own risk.\n//\n//\n\nglobal string $gMainPane;\nif (`paneLayout -exists $gMainPane`) {\n\n\tglobal int $gUseScenePanelConfig;\n\tint    $useSceneConfig = $gUseScenePanelConfig;\n\tint    $menusOkayInPanels = `optionVar -q allowMenusInPanels`;\tint    $nVisPanes = `paneLayout -q -nvp $gMainPane`;\n\tint    $nPanes = 0;\n\tstring $editorName;\n\tstring $panelName;\n\tstring $itemFilterName;\n\tstring $panelConfig;\n\n\t//\n\t//  get current state of the UI\n\t//\n\tsceneUIReplacement -update $gMainPane;\n\n\t$panelName = `sceneUIReplacement -getNextPanel \"modelPanel\" (localizedPanelLabel(\"Top View\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tmodelPanel -edit -l (localizedPanelLabel(\"Top View\")) -mbv $menusOkayInPanels  $panelName;\n\t\t$editorName = $panelName;\n        modelEditor -e \n            -camera \"top\" \n            -useInteractiveMode 0\n            -displayLights \"default\" \n            -displayAppearance \"smoothShaded\" \n            -activeOnly 0\n"
		+ "            -ignorePanZoom 0\n            -wireframeOnShaded 0\n            -headsUpDisplay 1\n            -holdOuts 1\n            -selectionHiliteDisplay 1\n            -useDefaultMaterial 0\n            -bufferMode \"double\" \n            -twoSidedLighting 0\n            -backfaceCulling 0\n            -xray 0\n            -jointXray 0\n            -activeComponentsXray 0\n            -displayTextures 0\n            -smoothWireframe 0\n            -lineWidth 1\n            -textureAnisotropic 0\n            -textureHilight 1\n            -textureSampling 2\n            -textureDisplay \"modulate\" \n            -textureMaxSize 32768\n            -fogging 0\n            -fogSource \"fragment\" \n            -fogMode \"linear\" \n            -fogStart 0\n            -fogEnd 100\n            -fogDensity 0.1\n            -fogColor 0.5 0.5 0.5 1 \n            -depthOfFieldPreview 1\n            -maxConstantTransparency 1\n            -rendererName \"vp2Renderer\" \n            -objectFilterShowInHUD 1\n            -isFiltered 0\n            -colorResolution 256 256 \n"
		+ "            -bumpResolution 512 512 \n            -textureCompression 0\n            -transparencyAlgorithm \"frontAndBackCull\" \n            -transpInShadows 0\n            -cullingOverride \"none\" \n            -lowQualityLighting 0\n            -maximumNumHardwareLights 1\n            -occlusionCulling 0\n            -shadingModel 0\n            -useBaseRenderer 0\n            -useReducedRenderer 0\n            -smallObjectCulling 0\n            -smallObjectThreshold -1 \n            -interactiveDisableShadows 0\n            -interactiveBackFaceCull 0\n            -sortTransparent 1\n            -controllers 1\n            -nurbsCurves 1\n            -nurbsSurfaces 1\n            -polymeshes 1\n            -subdivSurfaces 1\n            -planes 1\n            -lights 1\n            -cameras 1\n            -controlVertices 1\n            -hulls 1\n            -grid 1\n            -imagePlane 1\n            -joints 1\n            -ikHandles 1\n            -deformers 1\n            -dynamics 1\n            -particleInstancers 1\n            -fluids 1\n"
		+ "            -hairSystems 1\n            -follicles 1\n            -nCloths 1\n            -nParticles 1\n            -nRigids 1\n            -dynamicConstraints 1\n            -locators 1\n            -manipulators 1\n            -pluginShapes 1\n            -dimensions 1\n            -handles 1\n            -pivots 1\n            -textures 1\n            -strokes 1\n            -motionTrails 1\n            -clipGhosts 1\n            -greasePencils 1\n            -shadows 0\n            -captureSequenceNumber -1\n            -width 1\n            -height 1\n            -sceneRenderFilter 0\n            $editorName;\n        modelEditor -e -viewSelected 0 $editorName;\n        modelEditor -e \n            -pluginObjects \"gpuCacheDisplayFilter\" 1 \n            $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextPanel \"modelPanel\" (localizedPanelLabel(\"Side View\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tmodelPanel -edit -l (localizedPanelLabel(\"Side View\")) -mbv $menusOkayInPanels  $panelName;\n"
		+ "\t\t$editorName = $panelName;\n        modelEditor -e \n            -camera \"side\" \n            -useInteractiveMode 0\n            -displayLights \"default\" \n            -displayAppearance \"smoothShaded\" \n            -activeOnly 0\n            -ignorePanZoom 0\n            -wireframeOnShaded 0\n            -headsUpDisplay 1\n            -holdOuts 1\n            -selectionHiliteDisplay 1\n            -useDefaultMaterial 0\n            -bufferMode \"double\" \n            -twoSidedLighting 0\n            -backfaceCulling 0\n            -xray 0\n            -jointXray 0\n            -activeComponentsXray 0\n            -displayTextures 0\n            -smoothWireframe 0\n            -lineWidth 1\n            -textureAnisotropic 0\n            -textureHilight 1\n            -textureSampling 2\n            -textureDisplay \"modulate\" \n            -textureMaxSize 32768\n            -fogging 0\n            -fogSource \"fragment\" \n            -fogMode \"linear\" \n            -fogStart 0\n            -fogEnd 100\n            -fogDensity 0.1\n            -fogColor 0.5 0.5 0.5 1 \n"
		+ "            -depthOfFieldPreview 1\n            -maxConstantTransparency 1\n            -rendererName \"vp2Renderer\" \n            -objectFilterShowInHUD 1\n            -isFiltered 0\n            -colorResolution 256 256 \n            -bumpResolution 512 512 \n            -textureCompression 0\n            -transparencyAlgorithm \"frontAndBackCull\" \n            -transpInShadows 0\n            -cullingOverride \"none\" \n            -lowQualityLighting 0\n            -maximumNumHardwareLights 1\n            -occlusionCulling 0\n            -shadingModel 0\n            -useBaseRenderer 0\n            -useReducedRenderer 0\n            -smallObjectCulling 0\n            -smallObjectThreshold -1 \n            -interactiveDisableShadows 0\n            -interactiveBackFaceCull 0\n            -sortTransparent 1\n            -controllers 1\n            -nurbsCurves 1\n            -nurbsSurfaces 1\n            -polymeshes 1\n            -subdivSurfaces 1\n            -planes 1\n            -lights 1\n            -cameras 1\n            -controlVertices 1\n"
		+ "            -hulls 1\n            -grid 1\n            -imagePlane 1\n            -joints 1\n            -ikHandles 1\n            -deformers 1\n            -dynamics 1\n            -particleInstancers 1\n            -fluids 1\n            -hairSystems 1\n            -follicles 1\n            -nCloths 1\n            -nParticles 1\n            -nRigids 1\n            -dynamicConstraints 1\n            -locators 1\n            -manipulators 1\n            -pluginShapes 1\n            -dimensions 1\n            -handles 1\n            -pivots 1\n            -textures 1\n            -strokes 1\n            -motionTrails 1\n            -clipGhosts 1\n            -greasePencils 1\n            -shadows 0\n            -captureSequenceNumber -1\n            -width 1\n            -height 1\n            -sceneRenderFilter 0\n            $editorName;\n        modelEditor -e -viewSelected 0 $editorName;\n        modelEditor -e \n            -pluginObjects \"gpuCacheDisplayFilter\" 1 \n            $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n"
		+ "\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextPanel \"modelPanel\" (localizedPanelLabel(\"Front View\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tmodelPanel -edit -l (localizedPanelLabel(\"Front View\")) -mbv $menusOkayInPanels  $panelName;\n\t\t$editorName = $panelName;\n        modelEditor -e \n            -camera \"front\" \n            -useInteractiveMode 0\n            -displayLights \"default\" \n            -displayAppearance \"smoothShaded\" \n            -activeOnly 0\n            -ignorePanZoom 0\n            -wireframeOnShaded 0\n            -headsUpDisplay 1\n            -holdOuts 1\n            -selectionHiliteDisplay 1\n            -useDefaultMaterial 0\n            -bufferMode \"double\" \n            -twoSidedLighting 0\n            -backfaceCulling 0\n            -xray 0\n            -jointXray 0\n            -activeComponentsXray 0\n            -displayTextures 0\n            -smoothWireframe 0\n            -lineWidth 1\n            -textureAnisotropic 0\n            -textureHilight 1\n            -textureSampling 2\n"
		+ "            -textureDisplay \"modulate\" \n            -textureMaxSize 32768\n            -fogging 0\n            -fogSource \"fragment\" \n            -fogMode \"linear\" \n            -fogStart 0\n            -fogEnd 100\n            -fogDensity 0.1\n            -fogColor 0.5 0.5 0.5 1 \n            -depthOfFieldPreview 1\n            -maxConstantTransparency 1\n            -rendererName \"vp2Renderer\" \n            -objectFilterShowInHUD 1\n            -isFiltered 0\n            -colorResolution 256 256 \n            -bumpResolution 512 512 \n            -textureCompression 0\n            -transparencyAlgorithm \"frontAndBackCull\" \n            -transpInShadows 0\n            -cullingOverride \"none\" \n            -lowQualityLighting 0\n            -maximumNumHardwareLights 1\n            -occlusionCulling 0\n            -shadingModel 0\n            -useBaseRenderer 0\n            -useReducedRenderer 0\n            -smallObjectCulling 0\n            -smallObjectThreshold -1 \n            -interactiveDisableShadows 0\n            -interactiveBackFaceCull 0\n"
		+ "            -sortTransparent 1\n            -controllers 1\n            -nurbsCurves 1\n            -nurbsSurfaces 1\n            -polymeshes 1\n            -subdivSurfaces 1\n            -planes 1\n            -lights 1\n            -cameras 1\n            -controlVertices 1\n            -hulls 1\n            -grid 1\n            -imagePlane 1\n            -joints 1\n            -ikHandles 1\n            -deformers 1\n            -dynamics 1\n            -particleInstancers 1\n            -fluids 1\n            -hairSystems 1\n            -follicles 1\n            -nCloths 1\n            -nParticles 1\n            -nRigids 1\n            -dynamicConstraints 1\n            -locators 1\n            -manipulators 1\n            -pluginShapes 1\n            -dimensions 1\n            -handles 1\n            -pivots 1\n            -textures 1\n            -strokes 1\n            -motionTrails 1\n            -clipGhosts 1\n            -greasePencils 1\n            -shadows 0\n            -captureSequenceNumber -1\n            -width 1\n            -height 1\n"
		+ "            -sceneRenderFilter 0\n            $editorName;\n        modelEditor -e -viewSelected 0 $editorName;\n        modelEditor -e \n            -pluginObjects \"gpuCacheDisplayFilter\" 1 \n            $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextPanel \"modelPanel\" (localizedPanelLabel(\"Persp View\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tmodelPanel -edit -l (localizedPanelLabel(\"Persp View\")) -mbv $menusOkayInPanels  $panelName;\n\t\t$editorName = $panelName;\n        modelEditor -e \n            -camera \"persp\" \n            -useInteractiveMode 0\n            -displayLights \"default\" \n            -displayAppearance \"smoothShaded\" \n            -activeOnly 0\n            -ignorePanZoom 0\n            -wireframeOnShaded 0\n            -headsUpDisplay 1\n            -holdOuts 1\n            -selectionHiliteDisplay 1\n            -useDefaultMaterial 0\n            -bufferMode \"double\" \n            -twoSidedLighting 0\n            -backfaceCulling 0\n"
		+ "            -xray 0\n            -jointXray 0\n            -activeComponentsXray 0\n            -displayTextures 0\n            -smoothWireframe 0\n            -lineWidth 1\n            -textureAnisotropic 0\n            -textureHilight 1\n            -textureSampling 2\n            -textureDisplay \"modulate\" \n            -textureMaxSize 32768\n            -fogging 0\n            -fogSource \"fragment\" \n            -fogMode \"linear\" \n            -fogStart 0\n            -fogEnd 100\n            -fogDensity 0.1\n            -fogColor 0.5 0.5 0.5 1 \n            -depthOfFieldPreview 1\n            -maxConstantTransparency 1\n            -rendererName \"vp2Renderer\" \n            -objectFilterShowInHUD 1\n            -isFiltered 0\n            -colorResolution 256 256 \n            -bumpResolution 512 512 \n            -textureCompression 0\n            -transparencyAlgorithm \"frontAndBackCull\" \n            -transpInShadows 0\n            -cullingOverride \"none\" \n            -lowQualityLighting 0\n            -maximumNumHardwareLights 1\n            -occlusionCulling 0\n"
		+ "            -shadingModel 0\n            -useBaseRenderer 0\n            -useReducedRenderer 0\n            -smallObjectCulling 0\n            -smallObjectThreshold -1 \n            -interactiveDisableShadows 0\n            -interactiveBackFaceCull 0\n            -sortTransparent 1\n            -controllers 1\n            -nurbsCurves 1\n            -nurbsSurfaces 1\n            -polymeshes 1\n            -subdivSurfaces 1\n            -planes 1\n            -lights 1\n            -cameras 1\n            -controlVertices 1\n            -hulls 1\n            -grid 1\n            -imagePlane 1\n            -joints 1\n            -ikHandles 1\n            -deformers 1\n            -dynamics 1\n            -particleInstancers 1\n            -fluids 1\n            -hairSystems 1\n            -follicles 1\n            -nCloths 1\n            -nParticles 1\n            -nRigids 1\n            -dynamicConstraints 1\n            -locators 1\n            -manipulators 1\n            -pluginShapes 1\n            -dimensions 1\n            -handles 1\n            -pivots 1\n"
		+ "            -textures 1\n            -strokes 1\n            -motionTrails 1\n            -clipGhosts 1\n            -greasePencils 1\n            -shadows 0\n            -captureSequenceNumber -1\n            -width 796\n            -height 698\n            -sceneRenderFilter 0\n            $editorName;\n        modelEditor -e -viewSelected 0 $editorName;\n        modelEditor -e \n            -pluginObjects \"gpuCacheDisplayFilter\" 1 \n            $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextPanel \"outlinerPanel\" (localizedPanelLabel(\"ToggledOutliner\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\toutlinerPanel -edit -l (localizedPanelLabel(\"ToggledOutliner\")) -mbv $menusOkayInPanels  $panelName;\n\t\t$editorName = $panelName;\n        outlinerEditor -e \n            -showShapes 0\n            -showAssignedMaterials 0\n            -showTimeEditor 1\n            -showReferenceNodes 1\n            -showReferenceMembers 1\n            -showAttributes 0\n"
		+ "            -showConnected 0\n            -showAnimCurvesOnly 0\n            -showMuteInfo 0\n            -organizeByLayer 1\n            -organizeByClip 1\n            -showAnimLayerWeight 1\n            -autoExpandLayers 1\n            -autoExpand 0\n            -showDagOnly 1\n            -showAssets 1\n            -showContainedOnly 1\n            -showPublishedAsConnected 0\n            -showParentContainers 0\n            -showContainerContents 1\n            -ignoreDagHierarchy 0\n            -expandConnections 0\n            -showUpstreamCurves 1\n            -showUnitlessCurves 1\n            -showCompounds 1\n            -showLeafs 1\n            -showNumericAttrsOnly 0\n            -highlightActive 1\n            -autoSelectNewObjects 0\n            -doNotSelectNewObjects 0\n            -dropIsParent 1\n            -transmitFilters 0\n            -setFilter \"defaultSetFilter\" \n            -showSetMembers 1\n            -allowMultiSelection 1\n            -alwaysToggleSelect 0\n            -directSelect 0\n            -isSet 0\n            -isSetMember 0\n"
		+ "            -displayMode \"DAG\" \n            -expandObjects 0\n            -setsIgnoreFilters 1\n            -containersIgnoreFilters 0\n            -editAttrName 0\n            -showAttrValues 0\n            -highlightSecondary 0\n            -showUVAttrsOnly 0\n            -showTextureNodesOnly 0\n            -attrAlphaOrder \"default\" \n            -animLayerFilterOptions \"allAffecting\" \n            -sortOrder \"none\" \n            -longNames 0\n            -niceNames 1\n            -showNamespace 1\n            -showPinIcons 0\n            -mapMotionTrails 0\n            -ignoreHiddenAttribute 0\n            -ignoreOutlinerColor 0\n            -renderFilterVisible 0\n            -renderFilterIndex 0\n            -selectionOrder \"chronological\" \n            -expandAttribute 0\n            $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextPanel \"outlinerPanel\" (localizedPanelLabel(\"Outliner\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n"
		+ "\t\toutlinerPanel -edit -l (localizedPanelLabel(\"Outliner\")) -mbv $menusOkayInPanels  $panelName;\n\t\t$editorName = $panelName;\n        outlinerEditor -e \n            -showShapes 0\n            -showAssignedMaterials 0\n            -showTimeEditor 1\n            -showReferenceNodes 0\n            -showReferenceMembers 0\n            -showAttributes 0\n            -showConnected 0\n            -showAnimCurvesOnly 0\n            -showMuteInfo 0\n            -organizeByLayer 1\n            -organizeByClip 1\n            -showAnimLayerWeight 1\n            -autoExpandLayers 1\n            -autoExpand 0\n            -showDagOnly 1\n            -showAssets 1\n            -showContainedOnly 1\n            -showPublishedAsConnected 0\n            -showParentContainers 0\n            -showContainerContents 1\n            -ignoreDagHierarchy 0\n            -expandConnections 0\n            -showUpstreamCurves 1\n            -showUnitlessCurves 1\n            -showCompounds 1\n            -showLeafs 1\n            -showNumericAttrsOnly 0\n            -highlightActive 1\n"
		+ "            -autoSelectNewObjects 0\n            -doNotSelectNewObjects 0\n            -dropIsParent 1\n            -transmitFilters 0\n            -setFilter \"defaultSetFilter\" \n            -showSetMembers 1\n            -allowMultiSelection 1\n            -alwaysToggleSelect 0\n            -directSelect 0\n            -displayMode \"DAG\" \n            -expandObjects 0\n            -setsIgnoreFilters 1\n            -containersIgnoreFilters 0\n            -editAttrName 0\n            -showAttrValues 0\n            -highlightSecondary 0\n            -showUVAttrsOnly 0\n            -showTextureNodesOnly 0\n            -attrAlphaOrder \"default\" \n            -animLayerFilterOptions \"allAffecting\" \n            -sortOrder \"none\" \n            -longNames 0\n            -niceNames 1\n            -showNamespace 1\n            -showPinIcons 0\n            -mapMotionTrails 0\n            -ignoreHiddenAttribute 0\n            -ignoreOutlinerColor 0\n            -renderFilterVisible 0\n            $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n"
		+ "\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"graphEditor\" (localizedPanelLabel(\"Graph Editor\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Graph Editor\")) -mbv $menusOkayInPanels  $panelName;\n\n\t\t\t$editorName = ($panelName+\"OutlineEd\");\n            outlinerEditor -e \n                -showShapes 1\n                -showAssignedMaterials 0\n                -showTimeEditor 1\n                -showReferenceNodes 0\n                -showReferenceMembers 0\n                -showAttributes 1\n                -showConnected 1\n                -showAnimCurvesOnly 1\n                -showMuteInfo 0\n                -organizeByLayer 1\n                -organizeByClip 1\n                -showAnimLayerWeight 1\n                -autoExpandLayers 1\n                -autoExpand 1\n                -showDagOnly 0\n                -showAssets 1\n                -showContainedOnly 0\n                -showPublishedAsConnected 0\n                -showParentContainers 1\n"
		+ "                -showContainerContents 0\n                -ignoreDagHierarchy 0\n                -expandConnections 1\n                -showUpstreamCurves 1\n                -showUnitlessCurves 1\n                -showCompounds 0\n                -showLeafs 1\n                -showNumericAttrsOnly 1\n                -highlightActive 0\n                -autoSelectNewObjects 1\n                -doNotSelectNewObjects 0\n                -dropIsParent 1\n                -transmitFilters 1\n                -setFilter \"0\" \n                -showSetMembers 0\n                -allowMultiSelection 1\n                -alwaysToggleSelect 0\n                -directSelect 0\n                -displayMode \"DAG\" \n                -expandObjects 0\n                -setsIgnoreFilters 1\n                -containersIgnoreFilters 0\n                -editAttrName 0\n                -showAttrValues 0\n                -highlightSecondary 0\n                -showUVAttrsOnly 0\n                -showTextureNodesOnly 0\n                -attrAlphaOrder \"default\" \n                -animLayerFilterOptions \"allAffecting\" \n"
		+ "                -sortOrder \"none\" \n                -longNames 0\n                -niceNames 1\n                -showNamespace 1\n                -showPinIcons 1\n                -mapMotionTrails 1\n                -ignoreHiddenAttribute 0\n                -ignoreOutlinerColor 0\n                -renderFilterVisible 0\n                $editorName;\n\n\t\t\t$editorName = ($panelName+\"GraphEd\");\n            animCurveEditor -e \n                -displayKeys 1\n                -displayTangents 0\n                -displayActiveKeys 0\n                -displayActiveKeyTangents 1\n                -displayInfinities 0\n                -displayValues 0\n                -autoFit 1\n                -snapTime \"integer\" \n                -snapValue \"none\" \n                -showResults \"off\" \n                -showBufferCurves \"off\" \n                -smoothness \"fine\" \n                -resultSamples 1\n                -resultScreenSamples 0\n                -resultUpdate \"delayed\" \n                -showUpstreamCurves 1\n                -showCurveNames 0\n"
		+ "                -showActiveCurveNames 0\n                -stackedCurves 0\n                -stackedCurvesMin -1\n                -stackedCurvesMax 1\n                -stackedCurvesSpace 0.2\n                -displayNormalized 0\n                -preSelectionHighlight 0\n                -constrainDrag 0\n                -classicMode 1\n                -valueLinesToggle 0\n                $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"dopeSheetPanel\" (localizedPanelLabel(\"Dope Sheet\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Dope Sheet\")) -mbv $menusOkayInPanels  $panelName;\n\n\t\t\t$editorName = ($panelName+\"OutlineEd\");\n            outlinerEditor -e \n                -showShapes 1\n                -showAssignedMaterials 0\n                -showTimeEditor 1\n                -showReferenceNodes 0\n                -showReferenceMembers 0\n                -showAttributes 1\n"
		+ "                -showConnected 1\n                -showAnimCurvesOnly 1\n                -showMuteInfo 0\n                -organizeByLayer 1\n                -organizeByClip 1\n                -showAnimLayerWeight 1\n                -autoExpandLayers 1\n                -autoExpand 0\n                -showDagOnly 0\n                -showAssets 1\n                -showContainedOnly 0\n                -showPublishedAsConnected 0\n                -showParentContainers 1\n                -showContainerContents 0\n                -ignoreDagHierarchy 0\n                -expandConnections 1\n                -showUpstreamCurves 1\n                -showUnitlessCurves 0\n                -showCompounds 1\n                -showLeafs 1\n                -showNumericAttrsOnly 1\n                -highlightActive 0\n                -autoSelectNewObjects 0\n                -doNotSelectNewObjects 1\n                -dropIsParent 1\n                -transmitFilters 0\n                -setFilter \"0\" \n                -showSetMembers 0\n                -allowMultiSelection 1\n"
		+ "                -alwaysToggleSelect 0\n                -directSelect 0\n                -displayMode \"DAG\" \n                -expandObjects 0\n                -setsIgnoreFilters 1\n                -containersIgnoreFilters 0\n                -editAttrName 0\n                -showAttrValues 0\n                -highlightSecondary 0\n                -showUVAttrsOnly 0\n                -showTextureNodesOnly 0\n                -attrAlphaOrder \"default\" \n                -animLayerFilterOptions \"allAffecting\" \n                -sortOrder \"none\" \n                -longNames 0\n                -niceNames 1\n                -showNamespace 1\n                -showPinIcons 0\n                -mapMotionTrails 1\n                -ignoreHiddenAttribute 0\n                -ignoreOutlinerColor 0\n                -renderFilterVisible 0\n                $editorName;\n\n\t\t\t$editorName = ($panelName+\"DopeSheetEd\");\n            dopeSheetEditor -e \n                -displayKeys 1\n                -displayTangents 0\n                -displayActiveKeys 0\n                -displayActiveKeyTangents 0\n"
		+ "                -displayInfinities 0\n                -displayValues 0\n                -autoFit 0\n                -snapTime \"integer\" \n                -snapValue \"none\" \n                -outliner \"dopeSheetPanel1OutlineEd\" \n                -showSummary 1\n                -showScene 0\n                -hierarchyBelow 0\n                -showTicks 1\n                -selectionWindow 0 0 0 0 \n                $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"timeEditorPanel\" (localizedPanelLabel(\"Time Editor\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Time Editor\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"clipEditorPanel\" (localizedPanelLabel(\"Trax Editor\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Trax Editor\")) -mbv $menusOkayInPanels  $panelName;\n"
		+ "\n\t\t\t$editorName = clipEditorNameFromPanel($panelName);\n            clipEditor -e \n                -displayKeys 0\n                -displayTangents 0\n                -displayActiveKeys 0\n                -displayActiveKeyTangents 0\n                -displayInfinities 0\n                -displayValues 0\n                -autoFit 0\n                -snapTime \"none\" \n                -snapValue \"none\" \n                -initialized 0\n                -manageSequencer 0 \n                $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"sequenceEditorPanel\" (localizedPanelLabel(\"Camera Sequencer\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Camera Sequencer\")) -mbv $menusOkayInPanels  $panelName;\n\n\t\t\t$editorName = sequenceEditorNameFromPanel($panelName);\n            clipEditor -e \n                -displayKeys 0\n                -displayTangents 0\n                -displayActiveKeys 0\n"
		+ "                -displayActiveKeyTangents 0\n                -displayInfinities 0\n                -displayValues 0\n                -autoFit 0\n                -snapTime \"none\" \n                -snapValue \"none\" \n                -initialized 0\n                -manageSequencer 1 \n                $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"hyperGraphPanel\" (localizedPanelLabel(\"Hypergraph Hierarchy\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Hypergraph Hierarchy\")) -mbv $menusOkayInPanels  $panelName;\n\n\t\t\t$editorName = ($panelName+\"HyperGraphEd\");\n            hyperGraph -e \n                -graphLayoutStyle \"hierarchicalLayout\" \n                -orientation \"horiz\" \n                -mergeConnections 0\n                -zoom 1\n                -animateTransition 0\n                -showRelationships 1\n                -showShapes 0\n                -showDeformers 0\n"
		+ "                -showExpressions 0\n                -showConstraints 0\n                -showConnectionFromSelected 0\n                -showConnectionToSelected 0\n                -showConstraintLabels 0\n                -showUnderworld 0\n                -showInvisible 0\n                -transitionFrames 1\n                -opaqueContainers 0\n                -freeform 0\n                -imagePosition 0 0 \n                -imageScale 1\n                -imageEnabled 0\n                -graphType \"DAG\" \n                -heatMapDisplay 0\n                -updateSelection 1\n                -updateNodeAdded 1\n                -useDrawOverrideColor 0\n                -limitGraphTraversal -1\n                -range 0 0 \n                -iconSize \"smallIcons\" \n                -showCachedConnections 0\n                $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"hyperShadePanel\" (localizedPanelLabel(\"Hypershade\")) `;\n\tif (\"\" != $panelName) {\n"
		+ "\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Hypershade\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"visorPanel\" (localizedPanelLabel(\"Visor\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Visor\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"nodeEditorPanel\" (localizedPanelLabel(\"Node Editor\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Node Editor\")) -mbv $menusOkayInPanels  $panelName;\n\n\t\t\t$editorName = ($panelName+\"NodeEditorEd\");\n            nodeEditor -e \n                -allAttributes 0\n                -allNodes 0\n                -autoSizeNodes 1\n                -consistentNameSize 1\n                -createNodeCommand \"nodeEdCreateNodeCommand\" \n"
		+ "                -connectNodeOnCreation 0\n                -connectOnDrop 0\n                -highlightConnections 0\n                -copyConnectionsOnPaste 0\n                -defaultPinnedState 0\n                -additiveGraphingMode 0\n                -settingsChangedCallback \"nodeEdSyncControls\" \n                -traversalDepthLimit -1\n                -keyPressCommand \"nodeEdKeyPressCommand\" \n                -nodeTitleMode \"name\" \n                -gridSnap 0\n                -gridVisibility 1\n                -crosshairOnEdgeDragging 0\n                -popupMenuScript \"nodeEdBuildPanelMenus\" \n                -showNamespace 1\n                -showShapes 1\n                -showSGShapes 0\n                -showTransforms 1\n                -useAssets 1\n                -syncedSelection 1\n                -extendToShapes 1\n                -activeTab -1\n                -editorMode \"default\" \n                $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"createNodePanel\" (localizedPanelLabel(\"Create Node\")) `;\n"
		+ "\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Create Node\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"polyTexturePlacementPanel\" (localizedPanelLabel(\"UV Editor\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"UV Editor\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"renderWindowPanel\" (localizedPanelLabel(\"Render View\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Render View\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextPanel \"shapePanel\" (localizedPanelLabel(\"Shape Editor\")) `;\n"
		+ "\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tshapePanel -edit -l (localizedPanelLabel(\"Shape Editor\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextPanel \"posePanel\" (localizedPanelLabel(\"Pose Editor\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tposePanel -edit -l (localizedPanelLabel(\"Pose Editor\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"dynRelEdPanel\" (localizedPanelLabel(\"Dynamic Relationships\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Dynamic Relationships\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"relationshipPanel\" (localizedPanelLabel(\"Relationship Editor\")) `;\n"
		+ "\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Relationship Editor\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"referenceEditorPanel\" (localizedPanelLabel(\"Reference Editor\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Reference Editor\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"componentEditorPanel\" (localizedPanelLabel(\"Component Editor\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Component Editor\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"dynPaintScriptedPanelType\" (localizedPanelLabel(\"Paint Effects\")) `;\n"
		+ "\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Paint Effects\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"scriptEditorPanel\" (localizedPanelLabel(\"Script Editor\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Script Editor\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"profilerPanel\" (localizedPanelLabel(\"Profiler Tool\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Profiler Tool\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"contentBrowserPanel\" (localizedPanelLabel(\"Content Browser\")) `;\n"
		+ "\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Content Browser\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\tif ($useSceneConfig) {\n        string $configName = `getPanel -cwl (localizedPanelLabel(\"Current Layout\"))`;\n        if (\"\" != $configName) {\n\t\t\tpanelConfiguration -edit -label (localizedPanelLabel(\"Current Layout\")) \n\t\t\t\t-userCreated false\n\t\t\t\t-defaultImage \"vacantCell.xP:/\"\n\t\t\t\t-image \"\"\n\t\t\t\t-sc false\n\t\t\t\t-configString \"global string $gMainPane; paneLayout -e -cn \\\"single\\\" -ps 1 100 100 $gMainPane;\"\n\t\t\t\t-removeAllPanels\n\t\t\t\t-ap false\n\t\t\t\t\t(localizedPanelLabel(\"Persp View\")) \n\t\t\t\t\t\"modelPanel\"\n"
		+ "\t\t\t\t\t\"$panelName = `modelPanel -unParent -l (localizedPanelLabel(\\\"Persp View\\\")) -mbv $menusOkayInPanels `;\\n$editorName = $panelName;\\nmodelEditor -e \\n    -cam `findStartUpCamera persp` \\n    -useInteractiveMode 0\\n    -displayLights \\\"default\\\" \\n    -displayAppearance \\\"smoothShaded\\\" \\n    -activeOnly 0\\n    -ignorePanZoom 0\\n    -wireframeOnShaded 0\\n    -headsUpDisplay 1\\n    -holdOuts 1\\n    -selectionHiliteDisplay 1\\n    -useDefaultMaterial 0\\n    -bufferMode \\\"double\\\" \\n    -twoSidedLighting 0\\n    -backfaceCulling 0\\n    -xray 0\\n    -jointXray 0\\n    -activeComponentsXray 0\\n    -displayTextures 0\\n    -smoothWireframe 0\\n    -lineWidth 1\\n    -textureAnisotropic 0\\n    -textureHilight 1\\n    -textureSampling 2\\n    -textureDisplay \\\"modulate\\\" \\n    -textureMaxSize 32768\\n    -fogging 0\\n    -fogSource \\\"fragment\\\" \\n    -fogMode \\\"linear\\\" \\n    -fogStart 0\\n    -fogEnd 100\\n    -fogDensity 0.1\\n    -fogColor 0.5 0.5 0.5 1 \\n    -depthOfFieldPreview 1\\n    -maxConstantTransparency 1\\n    -rendererName \\\"vp2Renderer\\\" \\n    -objectFilterShowInHUD 1\\n    -isFiltered 0\\n    -colorResolution 256 256 \\n    -bumpResolution 512 512 \\n    -textureCompression 0\\n    -transparencyAlgorithm \\\"frontAndBackCull\\\" \\n    -transpInShadows 0\\n    -cullingOverride \\\"none\\\" \\n    -lowQualityLighting 0\\n    -maximumNumHardwareLights 1\\n    -occlusionCulling 0\\n    -shadingModel 0\\n    -useBaseRenderer 0\\n    -useReducedRenderer 0\\n    -smallObjectCulling 0\\n    -smallObjectThreshold -1 \\n    -interactiveDisableShadows 0\\n    -interactiveBackFaceCull 0\\n    -sortTransparent 1\\n    -controllers 1\\n    -nurbsCurves 1\\n    -nurbsSurfaces 1\\n    -polymeshes 1\\n    -subdivSurfaces 1\\n    -planes 1\\n    -lights 1\\n    -cameras 1\\n    -controlVertices 1\\n    -hulls 1\\n    -grid 1\\n    -imagePlane 1\\n    -joints 1\\n    -ikHandles 1\\n    -deformers 1\\n    -dynamics 1\\n    -particleInstancers 1\\n    -fluids 1\\n    -hairSystems 1\\n    -follicles 1\\n    -nCloths 1\\n    -nParticles 1\\n    -nRigids 1\\n    -dynamicConstraints 1\\n    -locators 1\\n    -manipulators 1\\n    -pluginShapes 1\\n    -dimensions 1\\n    -handles 1\\n    -pivots 1\\n    -textures 1\\n    -strokes 1\\n    -motionTrails 1\\n    -clipGhosts 1\\n    -greasePencils 1\\n    -shadows 0\\n    -captureSequenceNumber -1\\n    -width 796\\n    -height 698\\n    -sceneRenderFilter 0\\n    $editorName;\\nmodelEditor -e -viewSelected 0 $editorName;\\nmodelEditor -e \\n    -pluginObjects \\\"gpuCacheDisplayFilter\\\" 1 \\n    $editorName\"\n"
		+ "\t\t\t\t\t\"modelPanel -edit -l (localizedPanelLabel(\\\"Persp View\\\")) -mbv $menusOkayInPanels  $panelName;\\n$editorName = $panelName;\\nmodelEditor -e \\n    -cam `findStartUpCamera persp` \\n    -useInteractiveMode 0\\n    -displayLights \\\"default\\\" \\n    -displayAppearance \\\"smoothShaded\\\" \\n    -activeOnly 0\\n    -ignorePanZoom 0\\n    -wireframeOnShaded 0\\n    -headsUpDisplay 1\\n    -holdOuts 1\\n    -selectionHiliteDisplay 1\\n    -useDefaultMaterial 0\\n    -bufferMode \\\"double\\\" \\n    -twoSidedLighting 0\\n    -backfaceCulling 0\\n    -xray 0\\n    -jointXray 0\\n    -activeComponentsXray 0\\n    -displayTextures 0\\n    -smoothWireframe 0\\n    -lineWidth 1\\n    -textureAnisotropic 0\\n    -textureHilight 1\\n    -textureSampling 2\\n    -textureDisplay \\\"modulate\\\" \\n    -textureMaxSize 32768\\n    -fogging 0\\n    -fogSource \\\"fragment\\\" \\n    -fogMode \\\"linear\\\" \\n    -fogStart 0\\n    -fogEnd 100\\n    -fogDensity 0.1\\n    -fogColor 0.5 0.5 0.5 1 \\n    -depthOfFieldPreview 1\\n    -maxConstantTransparency 1\\n    -rendererName \\\"vp2Renderer\\\" \\n    -objectFilterShowInHUD 1\\n    -isFiltered 0\\n    -colorResolution 256 256 \\n    -bumpResolution 512 512 \\n    -textureCompression 0\\n    -transparencyAlgorithm \\\"frontAndBackCull\\\" \\n    -transpInShadows 0\\n    -cullingOverride \\\"none\\\" \\n    -lowQualityLighting 0\\n    -maximumNumHardwareLights 1\\n    -occlusionCulling 0\\n    -shadingModel 0\\n    -useBaseRenderer 0\\n    -useReducedRenderer 0\\n    -smallObjectCulling 0\\n    -smallObjectThreshold -1 \\n    -interactiveDisableShadows 0\\n    -interactiveBackFaceCull 0\\n    -sortTransparent 1\\n    -controllers 1\\n    -nurbsCurves 1\\n    -nurbsSurfaces 1\\n    -polymeshes 1\\n    -subdivSurfaces 1\\n    -planes 1\\n    -lights 1\\n    -cameras 1\\n    -controlVertices 1\\n    -hulls 1\\n    -grid 1\\n    -imagePlane 1\\n    -joints 1\\n    -ikHandles 1\\n    -deformers 1\\n    -dynamics 1\\n    -particleInstancers 1\\n    -fluids 1\\n    -hairSystems 1\\n    -follicles 1\\n    -nCloths 1\\n    -nParticles 1\\n    -nRigids 1\\n    -dynamicConstraints 1\\n    -locators 1\\n    -manipulators 1\\n    -pluginShapes 1\\n    -dimensions 1\\n    -handles 1\\n    -pivots 1\\n    -textures 1\\n    -strokes 1\\n    -motionTrails 1\\n    -clipGhosts 1\\n    -greasePencils 1\\n    -shadows 0\\n    -captureSequenceNumber -1\\n    -width 796\\n    -height 698\\n    -sceneRenderFilter 0\\n    $editorName;\\nmodelEditor -e -viewSelected 0 $editorName;\\nmodelEditor -e \\n    -pluginObjects \\\"gpuCacheDisplayFilter\\\" 1 \\n    $editorName\"\n"
		+ "\t\t\t\t$configName;\n\n            setNamedPanelLayout (localizedPanelLabel(\"Current Layout\"));\n        }\n\n        panelHistory -e -clear mainPanelHistory;\n        sceneUIReplacement -clear;\n\t}\n\n\ngrid -spacing 5 -size 12 -divisions 5 -displayAxes yes -displayGridLines yes -displayDivisionLines yes -displayPerspectiveLabels no -displayOrthographicLabels no -displayAxesBold yes -perspectiveLabelPosition axis -orthographicLabelPosition edge;\nviewManip -drawCompass 0 -compassAngle 0 -frontParameters \"\" -homeParameters \"\" -selectionLockParameters \"\";\n}\n");
	setAttr ".st" 3;
createNode script -n "sceneConfigurationScriptNode";
	rename -uid "15C8E880-4C20-8E15-4993-C4BA3FB63FBE";
	setAttr ".b" -type "string" "playbackOptions -min 1 -max 120 -ast 1 -aet 200 ";
	setAttr ".st" 6;
select -ne :time1;
	setAttr ".o" 1;
	setAttr ".unw" 1;
select -ne :hardwareRenderingGlobals;
	setAttr ".otfna" -type "stringArray" 22 "NURBS Curves" "NURBS Surfaces" "Polygons" "Subdiv Surface" "Particles" "Particle Instance" "Fluids" "Strokes" "Image Planes" "UI" "Lights" "Cameras" "Locators" "Joints" "IK Handles" "Deformers" "Motion Trails" "Components" "Hair Systems" "Follicles" "Misc. UI" "Ornaments"  ;
	setAttr ".otfva" -type "Int32Array" 22 0 1 1 1 1 1
		 1 1 1 0 0 0 0 0 0 0 0 0
		 0 0 0 0 ;
	setAttr ".fprt" yes;
select -ne :renderPartition;
	setAttr -s 2 ".st";
select -ne :renderGlobalsList1;
select -ne :defaultShaderList1;
	setAttr -s 4 ".s";
select -ne :postProcessList1;
	setAttr -s 2 ".p";
select -ne :defaultRenderingList1;
select -ne :initialShadingGroup;
	setAttr ".ro" yes;
select -ne :initialParticleSE;
	setAttr ".ro" yes;
select -ne :defaultRenderGlobals;
	setAttr ".ren" -type "string" "arnold";
select -ne :defaultResolution;
	setAttr ".pa" 1;
select -ne :hardwareRenderGlobals;
	setAttr ".ctrs" 256;
	setAttr ".btrs" 512;
connectAttr "pasted__polyMirror9.out" "pasted__pSphereShape4.i";
relationship "link" ":lightLinker1" ":initialShadingGroup.message" ":defaultLightSet.message";
relationship "link" ":lightLinker1" ":initialParticleSE.message" ":defaultLightSet.message";
relationship "shadowLink" ":lightLinker1" ":initialShadingGroup.message" ":defaultLightSet.message";
relationship "shadowLink" ":lightLinker1" ":initialParticleSE.message" ":defaultLightSet.message";
connectAttr "layerManager.dli[0]" "defaultLayer.id";
connectAttr "renderLayerManager.rlmi[0]" "defaultRenderLayer.rlid";
connectAttr "pasted__deleteComponent116.og" "pasted__polyMirror9.ip";
connectAttr "pasted__pSphere4.sp" "pasted__polyMirror9.sp";
connectAttr "pasted__pSphereShape4.wm" "pasted__polyMirror9.mp";
connectAttr "pasted__polyTweak534.out" "pasted__deleteComponent116.ig";
connectAttr "pasted__deleteComponent115.og" "pasted__polyTweak534.ip";
connectAttr "pasted__deleteComponent114.og" "pasted__deleteComponent115.ig";
connectAttr "pasted__deleteComponent113.og" "pasted__deleteComponent114.ig";
connectAttr "pasted__deleteComponent112.og" "pasted__deleteComponent113.ig";
connectAttr "pasted__deleteComponent111.og" "pasted__deleteComponent112.ig";
connectAttr "pasted__polyTweak533.out" "pasted__deleteComponent111.ig";
connectAttr "pasted__polyExtrudeFace20.out" "pasted__polyTweak533.ip";
connectAttr "pasted__polyTweak532.out" "pasted__polyExtrudeFace20.ip";
connectAttr "pasted__pSphereShape4.wm" "pasted__polyExtrudeFace20.mp";
connectAttr "pasted__polyExtrudeFace19.out" "pasted__polyTweak532.ip";
connectAttr "pasted__polyExtrudeFace18.out" "pasted__polyExtrudeFace19.ip";
connectAttr "pasted__pSphereShape4.wm" "pasted__polyExtrudeFace19.mp";
connectAttr "pasted__polyBevel6.out" "pasted__polyExtrudeFace18.ip";
connectAttr "pasted__pSphereShape4.wm" "pasted__polyExtrudeFace18.mp";
connectAttr "pasted__polyTweak531.out" "pasted__polyBevel6.ip";
connectAttr "pasted__pSphereShape4.wm" "pasted__polyBevel6.mp";
connectAttr "pasted__polyExtrudeFace17.out" "pasted__polyTweak531.ip";
connectAttr "pasted__polyExtrudeFace16.out" "pasted__polyExtrudeFace17.ip";
connectAttr "pasted__pSphereShape4.wm" "pasted__polyExtrudeFace17.mp";
connectAttr "pasted__polyTweak530.out" "pasted__polyExtrudeFace16.ip";
connectAttr "pasted__pSphereShape4.wm" "pasted__polyExtrudeFace16.mp";
connectAttr "pasted__polyExtrudeFace15.out" "pasted__polyTweak530.ip";
connectAttr "pasted__polyMapDel6.out" "pasted__polyExtrudeFace15.ip";
connectAttr "pasted__pSphereShape4.wm" "pasted__polyExtrudeFace15.mp";
connectAttr "pasted__polySplitRing19.out" "pasted__polyMapDel6.ip";
connectAttr "pasted__polySplitRing18.out" "pasted__polySplitRing19.ip";
connectAttr "pasted__pSphereShape4.wm" "pasted__polySplitRing19.mp";
connectAttr "pasted__polySplitRing17.out" "pasted__polySplitRing18.ip";
connectAttr "pasted__pSphereShape4.wm" "pasted__polySplitRing18.mp";
connectAttr "pasted__polySplitRing16.out" "pasted__polySplitRing17.ip";
connectAttr "pasted__pSphereShape4.wm" "pasted__polySplitRing17.mp";
connectAttr "pasted__deleteComponent110.og" "pasted__polySplitRing16.ip";
connectAttr "pasted__pSphereShape4.wm" "pasted__polySplitRing16.mp";
connectAttr "pasted__deleteComponent109.og" "pasted__deleteComponent110.ig";
connectAttr "pasted__deleteComponent108.og" "pasted__deleteComponent109.ig";
connectAttr "pasted__deleteComponent107.og" "pasted__deleteComponent108.ig";
connectAttr "pasted__deleteComponent106.og" "pasted__deleteComponent107.ig";
connectAttr "pasted__deleteComponent105.og" "pasted__deleteComponent106.ig";
connectAttr "pasted__deleteComponent104.og" "pasted__deleteComponent105.ig";
connectAttr "pasted__deleteComponent103.og" "pasted__deleteComponent104.ig";
connectAttr "pasted__deleteComponent102.og" "pasted__deleteComponent103.ig";
connectAttr "pasted__deleteComponent101.og" "pasted__deleteComponent102.ig";
connectAttr "pasted__deleteComponent100.og" "pasted__deleteComponent101.ig";
connectAttr "pasted__deleteComponent99.og" "pasted__deleteComponent100.ig";
connectAttr "pasted__deleteComponent98.og" "pasted__deleteComponent99.ig";
connectAttr "pasted__deleteComponent97.og" "pasted__deleteComponent98.ig";
connectAttr "pasted__deleteComponent96.og" "pasted__deleteComponent97.ig";
connectAttr "pasted__deleteComponent95.og" "pasted__deleteComponent96.ig";
connectAttr "pasted__deleteComponent94.og" "pasted__deleteComponent95.ig";
connectAttr "pasted__deleteComponent93.og" "pasted__deleteComponent94.ig";
connectAttr "pasted__deleteComponent92.og" "pasted__deleteComponent93.ig";
connectAttr "pasted__deleteComponent91.og" "pasted__deleteComponent92.ig";
connectAttr "pasted__deleteComponent90.og" "pasted__deleteComponent91.ig";
connectAttr "pasted__polySphere4.out" "pasted__deleteComponent90.ig";
connectAttr "defaultRenderLayer.msg" ":defaultRenderingList1.r" -na;
connectAttr "pasted__pSphereShape4.iog" ":initialShadingGroup.dsm" -na;
// End of helmet_template.ma
