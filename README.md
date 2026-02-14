# Template controller for player
### cheat sheet
Speed — field float

transform.position += new Vector3(0f, 1f, 0f) * Speed * Time.deltaTime;

In the documentation, there are unit vectors, for example

Vector3.up is the same as new Vector3(0f, 1f, 0f)

Moving an object taking its rotation into account

transform.position += transform.forward * Speed * Time.deltaTime;

Moving an object using a method

transform.Translate(0f, 0f, 1f * Speed * Time.deltaTime);

Physical force applied to an object is created using Rigidbody

GetComponent<Rigidbody>().velocity = transform.forward * Speed;

Physically moving an object using a method

GetComponent<Rigidbody>().MovePosition(transform.position + transform.forward * Speed * Time.deltaTime);

Rotating an object

transform.eulerAngles += new Vector3(Time.deltaTime * Speed, 0f, 0f);

Rotating an object using a method

transform.Rotate(0f, 0f, Time.deltaTime * Speed);

Physically rotating an object

GetComponent<Rigidbody>().angularVelocity = new Vector3(0f, 1f, 0f);

Physically rotating an object using a method

Vector3 resultEuler = transform.eulerAngles + new Vector3(0f, 1f, 0f);

GetComponent<Rigidbody>().MoveRotation(Quaternion.Euler(resultEuler));

---
