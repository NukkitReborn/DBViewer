//  leveldb-sharp
// 
//  Copyright (c) 2011 The LevelDB Authors
//  Copyright (c) 2012-2013, Mirco Bauer <meebey@meebey.net>
//  All rights reserved.
// 
//  Redistribution and use in source and binary forms, with or without
//  modification, are permitted provided that the following conditions are
//  met:
// 
//     * Redistributions of source code must retain the above copyright
//       notice, this list of conditions and the following disclaimer.
//     * Redistributions in binary form must reproduce the above
//       copyright notice, this list of conditions and the following disclaimer
//       in the documentation and/or other materials provided with the
//       distribution.
//     * Neither the name of Google Inc. nor the names of its
//       contributors may be used to endorse or promote products derived from
//       this software without specific prior written permission.
// 
//  THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS
//  "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT
//  LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR
//  A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT
//  OWNER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL,
//  SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT
//  LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE,
//  DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY
//  THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
//  (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE
//  OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.

using System;

namespace LevelDB
{
    /// <summary>
    /// Write options
    /// </summary>
    public class WriteOptions
    {
        /// <summary>
        /// Native handle
        /// </summary>
        public IntPtr Handle { get; private set; }

        /// <summary>
        /// This sync flag can be turned on for a particular write to make the
        /// write operation not return until the data being written has been
        /// pushed all the way to persistent storage.
        /// By default, each write to leveldb is asynchronous: it returns after
        /// pushing the write from the process into the operating system. The
        /// transfer from operating system memory to the underlying persistent
        /// storage happens asynchronously.
        /// </summary>
        public bool Sync {
            set {
                Native.leveldb_writeoptions_set_sync(Handle, value);
            }
        }

        public WriteOptions()
        {
            Handle = Native.leveldb_writeoptions_create();
        }

        ~WriteOptions()
        {
            Native.leveldb_writeoptions_destroy(Handle);
        }
    }
}
