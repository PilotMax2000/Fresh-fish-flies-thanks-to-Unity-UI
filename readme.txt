
++++++++++++++++++++++++++++++++++INSTRUCTION++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
You can use RodsSlotsGenerator component for changing the number of slots to generate (1 to 10). It is bind to 
_SceneLogic/RodsSlotsGerarator gameobjct in SampleScene.

++++++++++++++++++++++++++++++++++OPTIMIZATION+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
TOTAL RESULT: after optimization number of batches decreased from 100 (for 50 rods elements) to 30-36 for 100 elements.

Actions took for reducing draw calls:
	Moved all used sprites into sprite atlas (used Unity Sprite Atlas) => saved ~ 45 calls;
	Removed masking (where possible) =>  saved ~15 calls;
	Rearranged objects in a hierarchy (tried to group text elements and sprites for decreasing the material switching) =>  saved ~10 calls;

Other actions took for optimization:
	For all elements (if it was not necessary) turned off the "Raycast target" checkbox;
	Switched the second camera into Screen Space Overlay  mode (slightly faster), first one left in Screen Space mode (needed for rendering the rod 3D model properly);
	Removed Graphics Raycaster component on the second camera;
	Reduced the usage of Layout Groups where possible;
	Created a script for stopping the scrolling, when scrolling speed became unnoticeable for the user  - this decrease the time of FPS drop, which happens when scrolling is used;
	