
// The ICloner takes a source CloneSourceType and consumes its data
public interface ICopier<CloneSourceType> {

	void Copy(CloneSourceType source);
}

