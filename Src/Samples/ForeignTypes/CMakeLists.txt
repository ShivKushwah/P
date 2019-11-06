cmake_minimum_required (VERSION 3.1)
project (P)
set(projectName ForeignTypes)
find_package (Threads)
include_directories(~/Research/P-Secure-Fork/P/Bld/Drops/Prt/include)
add_definitions(-DPRT_PLAT_LINUXUSER)

add_executable(foreign_types
    ForeignStringType.c
    ForeignStringType.h
    ForeignTypesImpl.c
    Main.c
    ~/Research/P-Secure-Fork/P/Bld/Drops/Prt/include/ext_compat.h
    ~/Research/P-Secure-Fork/P/Bld/Drops/Prt/include/libhandler.h
    ~/Research/P-Secure-Fork/P/Bld/Drops/Prt/include/libhandler-internal.h
    ~/Research/P-Secure-Fork/P/Bld/Drops/Prt/include/Prt.h
    ~/Research/P-Secure-Fork/P/Bld/Drops/Prt/include/PrtConfig.h
    ~/Research/P-Secure-Fork/P/Bld/Drops/Prt/include/PrtExecution.h
    ~/Research/P-Secure-Fork/P/Bld/Drops/Prt/include/PrtLinuxUserConfig.h
    ~/Research/P-Secure-Fork/P/Bld/Drops/Prt/include/PrtProgram.h
    ~/Research/P-Secure-Fork/P/Bld/Drops/Prt/include/PrtTypes.h
    ~/Research/P-Secure-Fork/P/Bld/Drops/Prt/include/PrtValues.h
    ~/Research/P-Secure-Fork/P/Bld/Drops/Prt/include/sal.h)

target_link_libraries(foreign_types ${CMAKE_SOURCE_DIR}/../../../Bld/Drops/Prt/lib/libPrt_static.a /home/shiv/Research/ProgrammingEnclaves/Submodule/P/Ext/libhandler/out/gcc-amd64-linux-gnu/debug/libhandler.a ${CMAKE_THREAD_LIBS_INIT})
