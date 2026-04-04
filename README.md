# AI.Foundry.Local.RAG

A RAG application using Foundry Local to host models. 

The UI is a Blazor application.

## Project inception

Created into an empty git repository from the empty Aspire template using
```
dotnet new aspire-empty-starter -n AI.Foundry.Local.RAG -o . 
```

Aspire has been initialised using 
```
aspire init
```

## Hugging Face setup

The embedding model needs to be downloaded from Hugging Face using the [CLI](https://huggingface.co/docs/huggingface_hub/en/guides/cli). Install it by running
```
irm https://hf.co/cli/install.ps1 | iex
```

After installation, login by
```
hf auth login
```

This will ask you to enter a token from https://huggingface.co/settings/tokens - generate or copy the token then right click. The token will be saved so you shouldn't need to enter it again unless it has expired.


## References

https://github.com/davidfowl/aspire-ai-chat-demo/ 

[Utilizing Free AI Models with .NET Aspire - DotnetExpertsindia](https://dotnetexpertsindia.com/blog/net-aspire/)

---
https://www.reddit.com/r/dotnet/s/GP3o0SPKQD

https://github.com/yuniko-software/tokenizer-to-onnx-model

Embeddings via ONNX with Semantic Kernel for Local RAG Solutions in .NET – Juanlu, ElGuerre](https://elguerre.com/2025/05/25/implementing-embeddings-via-onnx-with-semantic-kernel-for-local-rag-solutions-in-net/)
