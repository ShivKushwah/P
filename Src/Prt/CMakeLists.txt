set ( P_Prt_Src_Path ${CMAKE_CURRENT_SOURCE_DIR} )
set ( API_PATH ${P_Prt_Src_Path}/API-SGX/ )
set ( Core_PATH ${P_Prt_Src_Path}/Core/ )
set ( LIBHANDLER_PATH ${P_Prt_Src_Path}/../../Ext/libhandler/)
set ( LIBHANDLERINC_PATH ${P_Prt_Src_Path}/../../Ext/libhandler/inc)
set ( LIBHANDLEROUT_PATH ${P_Prt_Src_Path}/../../Ext/libhandler/out)

ADD_CUSTOM_TARGET( 
  libhandler
  COMMAND ./configure
  COMMAND make depend
  COMMAND make
  WORKING_DIRECTORY ${LIBHANDLER_PATH}
)

if(SGX)
    set ( User_PATH ${P_Prt_Src_Path}/SGXUser/Trusted )
    set ( User_ADDITIONAL_SOURCE_FILES ${User_PATH}/PrtEnclave_t.c )
    # include_directories(
    #     ${SGX_SDK}/include
    #     ${SGX_SDK}/include/tlibc
    #     ${SGX_SDK}/include/stlport
    # )

    add_definitions(-DENCLAVE_STD_ALT)

    add_custom_command(
        OUTPUT ${User_PATH}/PrtEnclave_t.c
        COMMAND ${SGX_EDGER8R} --trusted ${User_PATH}/PrtEnclave.edl
            --search-path ${SGX_SDK}/include
            --search-path ${User_PATH}
            WORKING_DIRECTORY ${User_PATH}
        DEPENDS ${User_PATH}/PrtEnclave.edl
    )
elseif(Win32)
	set ( User_PATH ${P_Prt_Src_Path}/WinUser/ )
elseif(LINUX OR MACOSX)
	set ( User_PATH ${P_Prt_Src_Path}/LinuxUser/ )
endif()

set( PrtUser_Output_PATH ${PROJECT_SOURCE_DIR}/../Bld/Drops/Prt/)
set( LIBRARY_OUTPUT_PATH ${PrtUser_Output_PATH}/lib/ )
set( LIBRARY_OUTPUT_INCLUDE_PATH ${PrtUser_Output_PATH}/include/ )

file ( GLOB API_SRC ${API_PATH}/*.c ${API_PATH}/*.h )
file ( GLOB Core_SRC ${Core_PATH}/*.c ${Core_PATH}/*.h )
file ( GLOB User_SRC ${User_PATH}/*.c ${User_PATH}/*.h  )

set ( PrtUserSrc ${API_SRC} ${Core_SRC} ${User_SRC} ${User_ADDITIONAL_SOURCE_FILES} )

add_library(Prt OBJECT ${PrtUserSrc})
add_dependencies(Prt libhandler)

if (NOT Win32 AND NOT DEFINED SGX)
	find_package(Threads REQUIRED)
	if(THREADS_HAVE_PTHREAD_ARG)
	  set_property(TARGET Prt PROPERTY COMPILE_OPTIONS "-pthread")
	  set_property(TARGET Prt PROPERTY INTERFACE_COMPILE_OPTIONS "-pthread")
	endif()
	if(${CMAKE_THREAD_LIBS_INIT})
	  target_link_libraries(Prt ${CMAKE_THREAD_LIBS_INIT})
	endif()
endif()

set_property(TARGET Prt PROPERTY C_STANDARD 99)

IF( CMAKE_SYSTEM_PROCESSOR STREQUAL "x86_64" )
  SET_TARGET_PROPERTIES(Prt PROPERTIES COMPILE_FLAGS "-fPIC")
ENDIF( CMAKE_SYSTEM_PROCESSOR STREQUAL "x86_64" )

# add_library(Prt_test OBJECT ${PrtUserSrc})
if(SGX)    
    add_library(Prt_trusted_static STATIC $<TARGET_OBJECTS:Prt>)
    target_include_directories(Prt PUBLIC ${SGX_SDK}/include)
    target_include_directories(Prt PUBLIC ${SGX_SDK}/include/tlibc)
    target_include_directories(Prt PUBLIC ${SGX_SDK}/include/stlport)
    target_include_directories(Prt PUBLIC ${API_PATH})
    target_include_directories(Prt PUBLIC ${LIBHANDLERINC_PATH})
    target_include_directories(Prt PUBLIC ${LIBHANDLEROUT_PATH})
    target_include_directories(Prt PUBLIC ${Core_PATH})
    target_include_directories(Prt PUBLIC ${User_PATH})
    get_property(Prt_Published_Headers_PATHS TARGET Prt PROPERTY INTERFACE_INCLUDE_DIRECTORIES)
    target_include_directories(Prt_trusted_static PUBLIC ${Prt_Published_Headers_PATHS})
    Publish_Library_Header(Prt_trusted_static)
endif()

#Creates Prt_static2 below

set ( P_Prt_Src_Path ${CMAKE_CURRENT_SOURCE_DIR} )
set ( API_PATH2 ${P_Prt_Src_Path}/API/ )
set ( Core_PATH ${P_Prt_Src_Path}/Core/ )
set ( LIBHANDLER_PATH ${P_Prt_Src_Path}/../../Ext/libhandler/)
set ( LIBHANDLERINC_PATH ${P_Prt_Src_Path}/../../Ext/libhandler/inc)
set ( LIBHANDLEROUT_PATH ${P_Prt_Src_Path}/../../Ext/libhandler/out)

ADD_CUSTOM_TARGET( 
  libhandler2
  COMMAND ./configure
  COMMAND make depend
  COMMAND make
  WORKING_DIRECTORY ${LIBHANDLER_PATH}
)



set ( User_PATH2 ${P_Prt_Src_Path}/LinuxUser/ )
  
set( PrtUser_Output_PATH ${PROJECT_SOURCE_DIR}/../Bld/Drops/Prt/)
set( LIBRARY_OUTPUT_PATH ${PrtUser_Output_PATH}/lib/ )
set( LIBRARY_OUTPUT_INCLUDE_PATH ${PrtUser_Output_PATH}/include/ )

file ( GLOB API_SRC2 ${API_PATH2}/*.c ${API_PATH2}/*.h )
file ( GLOB Core_SRC ${Core_PATH}/*.c ${Core_PATH}/*.h )
file ( GLOB User_SRC2 ${User_PATH2}/*.c ${User_PATH2}/*.h  )

set ( PrtUserSrc2 ${API_SRC2} ${Core_SRC} ${User_SRC2}  )

add_library(Prt2 OBJECT ${PrtUserSrc2})
add_dependencies(Prt2 libhandler2)

# if (NOT Win32 AND NOT DEFINED SGX)
	find_package(Threads REQUIRED)
	# if(THREADS_HAVE_PTHREAD_ARG)
	  set_property(TARGET Prt2 PROPERTY COMPILE_OPTIONS "-pthread")
	  set_property(TARGET Prt2 PROPERTY INTERFACE_COMPILE_OPTIONS "-pthread")
	# endif()
	if(${CMAKE_THREAD_LIBS_INIT})
	  target_link_libraries(Prt2 ${CMAKE_THREAD_LIBS_INIT})
	endif()
# endif()

set_property(TARGET Prt2 PROPERTY C_STANDARD 99)

IF( CMAKE_SYSTEM_PROCESSOR STREQUAL "x86_64" )
  SET_TARGET_PROPERTIES(Prt2 PROPERTIES COMPILE_FLAGS "-fPIC")
ENDIF( CMAKE_SYSTEM_PROCESSOR STREQUAL "x86_64" )

# add_library(Prt_test OBJECT ${PrtUserSrc})

    add_library(Prt_static2 STATIC $<TARGET_OBJECTS:Prt2>)
    target_include_directories(Prt2 PUBLIC ${API_PATH2})
    target_include_directories(Prt2 PUBLIC ${LIBHANDLERINC_PATH})
    target_include_directories(Prt2 PUBLIC ${LIBHANDLEROUT_PATH})
    target_include_directories(Prt2 PUBLIC ${Core_PATH})
    target_include_directories(Prt2 PUBLIC ${User_PATH2})
    get_property(Prt_Published_Headers_PATHS2 TARGET Prt2 PROPERTY INTERFACE_INCLUDE_DIRECTORIES)
# need to manually set includes for static and shared libraries, from object library include path
    target_include_directories(Prt_static2 PUBLIC ${Prt_Published_Headers_PATHS2})
# target_include_directories(Prt_test PUBLIC ${Prt_Published_Headers_PATHS})

    Publish_Library_Header(Prt_static2)