# Unity Utilities

A bag of reusable extensions we keep using in Unity projects

### How to use

- Import extensions to expand the functionality of standard Unity classes
- Use `IMaybe<T>` interface to make your types optional
- Use chains of `optionalType.IfPresent(value => action(value).IfNotPresent(void => action)` to manage optional types safely
- Use `PrefabPool` to reuse created prefabs with `Spawn`/`Despawn` functionality (requires those prefabs to be properly reset `OnSpawn` though)

### How to install

In Package Manager click `+` -> `Add package from git URL...` and paste `https://github.com/Nebulate-me/Unity-Utilities.git`