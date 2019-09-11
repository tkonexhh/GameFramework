# GameFramework


GFrame

------Scripts

      ------Engine
      
            ------DataRecord   存档
            
                  ------DataClassHandler
                        存档的核心类
                        
                  ------DataDirtyHandler
                        
                  ------IDataClass
                        继承了DataDirtyHandler，提供了InitWithEmptyData()和OnDataLoadFinish()方法
            ------ResSystem 资源系统
                  ------Editor
                        -----—-AssetBundle
                               AssetAutoProcess 
                               继承AssetPostprocessor 用于当资源导入或移动的时候自动分配ABName
                   

